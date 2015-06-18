using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	public List<Item> equiped = new List<Item>();
	public GUISkin invSkin;
	private itemDatabase database;
	public bool showInventory = false;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;
	public PlayerStats myPlayer;
	private float HPbarWidth = 100;

	// Use this for initialization
	void Start () {
		myPlayer = GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer;
		for(int i = 0; i < (Literals.slotsX *Literals.slotsY);i++){
			slots.Add (new Item());
			inventory.Add (new Item());
		}

		for(int j = 0; j < Literals.equipSlots; j++){
			equiped.Add (new Item());
		}

		database = GameObject.Find("__GameManager").GetComponent<itemDatabase>();
		AddItem(200,5); //test potion
	}
	
	void Update(){
		if(Input.GetButtonDown ("Inventory")){
			if(showInventory && (GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount < Literals.invPrice )){ //allow you to close even if your gold is low
				showInventory = false;
			}
			if(GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount > Literals.invPrice){
				if(!showInventory)
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount -= Literals.invPrice;
				showInventory = !showInventory;
			}
		}
	}

	void OnGUI(){
		tooltip = "";
		GUI.skin = invSkin;
		if(showInventory){
			DrawInventory ();
			DrawEquip();
			if(showTooltip){
				float curH = invSkin.GetStyle("Tooltip").CalcSize(new GUIContent(tooltip)).y/5.4f;
				float mouseOffset = tooltip.Length;
				GUI.Box (new Rect(0,0,Screen.width/4.788f, curH),tooltip, invSkin.GetStyle ("Tooltip"));
			}
		}
		if(draggingItem){
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x-Literals.gridSize/2,Event.current.mousePosition.y-Literals.gridSize/2,Literals.gridSize,Literals.gridSize),draggedItem.itempic);
		}
	}

	void DrawEquip(){ //head,hands,torso,legs,feet,mainhand,offhand
		Event e = Event.current;
		int offSetY = 0,offSetX = 60,x = 0,s = 0;
		GUI.BeginGroup (new Rect(0,Screen.height/2-200,300,400));
		GUI.Box(new Rect(0,0,300,400),""); //place holder
		for(int y = 0; y < Literals.equipSlots; y++){
			Rect equipRect = new Rect(x*offSetX,y+offSetY,50,50);

			x++;
			if(y%3 == 0){
				offSetY += 100;
				x = 0;
				//print ("x is "+y*offSetX + " y is "+(y+offSetY));
			}
			GUI.Box(equipRect,"",invSkin.GetStyle ("Slot")); //legs
			if(equiped[y].itemname != null){
				GUI.DrawTexture(equipRect,equiped[y].itempic);
			}
		}
		GUI.EndGroup();



	}

	void DrawInventory(){
		Event e = Event.current;
		int i = 0;
		for(int y = 0;y < Literals.slotsY;y++){
			for(int x = 0;x < Literals.slotsX;x++){
				Rect slotRect = new Rect( (Screen.width - (2.5f*Literals.gridWidth)) + (x * Literals.invOffset) , (Screen.height - (1.5f*Literals.gridHeight)) + (y * Literals.invOffset),Literals.gridSize,Literals.gridSize);
				GUI.Box (slotRect,"",invSkin.GetStyle ("Slot"));
				slots[i] = inventory[i];
				checkTooltipDrag(i,slotRect,e);
				if(tooltip == ""){
					showTooltip = false;
				}

				i++;
			}
		}
	}


	private void checkTooltipDrag(int i, Rect slotRect,Event e){
		if(slots[i].itemname != null){
			GUI.DrawTexture (slotRect, slots[i].itempic);
			if(slotRect.Contains(e.mousePosition)){
				tooltip = CreateTooltip(slots[i]);
				showTooltip = true;
				if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem){
					draggingItem = true;
					prevIndex = i;
					draggedItem = slots[i];
					inventory[i] = new Item();
				}
				if(e.type == EventType.mouseUp && draggingItem){
					inventory[prevIndex] = inventory[i];
					inventory[i] = draggedItem;
					draggingItem = false;
					draggedItem = null;
				}
				if(e.isMouse && e.type == EventType.mouseDown && e.button == 1){
					if(slots[i].itemType == Item.ItemType.Consumable){
						UseConsumable(slots[i],i,true);
					}
					Equipables(i);
				}
			}
			
		}else{
			if(slotRect.Contains(e.mousePosition)){
				if(e.type == EventType.mouseUp && draggingItem){
					inventory[i] = draggedItem;
					draggingItem = false;
					draggedItem = null;
				}
			}
		}
	}

	private string CreateTooltip(Item item){
		tooltip += "<color=#ffffff>"+ item.itemname+"</color> \n\n";
		tooltip += "<color=#021353>"+ item.desc+"</color> \n\n\n";
		tooltip += "<color=#ff0000>Quantity: "+ item.quantity+"</color> \n";
		tooltip += "<color=#ff0000>Use Cost: "+ item.costtouse+"</color>";
		return tooltip;
	}


	public bool inventoryContains(int id){
		bool result = false;
		for(int i = 0; i < inventory.Count; i++){
			result = inventory[i].itemID == id;
			if(result){
				break;
			}
		}
		return result;
	}



	public void AddItem(int itemID,int quant){
		if(inventoryContains(itemID)){
			for(int i = 0; i < inventory.Count; i++){
				if(inventory[i].itemID == itemID){
					inventory[i].quantity += quant;
					break;
				}
			}
		}
		else{
			for(int i = 0; i < inventory.Count; i++){
				if(inventory[i].itemname == null){
					for(int j = 0; j < database.myItems.Count; j++){
						if(database.myItems[j].itemID == itemID){
							inventory[i] = database.myItems[j];
							inventory[i].quantity = quant;
						}
					}
					break;
				}
			}
		}
	}

	public void RemoveItem(int id){
		for(int i = 0; i < inventory.Count; i++){
			if(inventory[i].itemID == id){
				inventory[i] = new Item();
				break;
			}
		}
	}


	private void Equipables(int i){
		if(slots[i].itemType == Item.ItemType.Weapon){
			if(equiped[1].itemname == null){
				equiped[1] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showWeapon(equiped[1].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[1].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[1].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[1].health,true);
				//print("equiped: "+equiped[1].itemname);
			}else if(equiped[1].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[1].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[1].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[1].health,false);
				inventory[i] = equiped[1];
				inventory[i].quantity = 1;
				equiped[1] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showWeapon(equiped[1].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[1].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[1].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[1].health,true);
			}
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TargetEnemy>().goldCost = equiped[1].costtouse;
		}
		if(slots[i].itemType == Item.ItemType.Armor){
			if(equiped[2].itemname == null){
				equiped[2] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showArmor(equiped[2].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[2].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[2].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[2].health,true);
			}else if(equiped[2].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[2].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[2].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[2].health,false);
				inventory[i] = equiped[2];
				inventory[i].quantity = 1;
				equiped[2] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showArmor(equiped[2].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[2].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[2].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[2].health,true);
			}
		}
		if(slots[i].itemType == Item.ItemType.Feet){
			if(equiped[6].itemname == null){
				equiped[6] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showFeet(equiped[6].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[6].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[6].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[6].health,true);
			}else if(equiped[6].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[6].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[6].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[6].health,false);
				inventory[i] = equiped[6];
				inventory[i].quantity = 1;
				equiped[6] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showFeet(equiped[6].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[1].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[1].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[1].health,true);
			}
		}
		if(slots[i].itemType == Item.ItemType.Hands){
			if(equiped[4].itemname == null){
				equiped[4] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showHands(equiped[4].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[4].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[4].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[4].health,true);
			}else if(equiped[4].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[4].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[4].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[4].health,false);
				inventory[i] = equiped[4];
				inventory[i].quantity = 1;
				equiped[4] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showHands(equiped[4].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[1].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[1].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[1].health,true);
			}
		}
		if(slots[i].itemType == Item.ItemType.Head){
			if(equiped[0].itemname == null){
				equiped[0] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showHead(equiped[0].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[0].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[0].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[0].health,true);
			}else if(equiped[0].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[0].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[0].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[0].health,false);
				inventory[i] = equiped[0];
				inventory[i].quantity = 1;
				equiped[0] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showHead(equiped[0].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[0].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[0].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[0].health,true);
			}
		}
		if(slots[i].itemType == Item.ItemType.Legs){
			if(equiped[5].itemname == null){
				equiped[5] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[5].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[5].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[5].health,true);
			}else if(equiped[5].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[5].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[5].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[5].health,false);
				inventory[i] = equiped[5];
				inventory[i].quantity = 1;
				equiped[5] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[5].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[5].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[5].health,true);
			}
		}
		if(slots[i].itemType == Item.ItemType.Offhand){
			if(equiped[3].itemname == null){
				equiped[3] = slots[i];
				RemoveItem(slots[i].itemID);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showOffhand(equiped[3].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[3].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[3].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[3].health,true);
			}else if(equiped[3].itemname != null){
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[3].defense,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[3].power,false);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[3].health,false);
				inventory[i] = equiped[3];
				inventory[i].quantity = 1;
				equiped[3] = slots[i];
				slots[i] = inventory[i];
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().showOffhand(equiped[3].itemname);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateDefense(equiped[3].defense,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdatePower(equiped[3].power,true);
				GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer.UpdateHealth(equiped[3].health,true);
			}
		}
	}

	private void UseConsumable(Item item, int slot, bool deleteItem){
		switch(item.itemID){
		case 200:
		{
			if(GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount > item.costtouse){
				if(item.quantity > 1){
					item.quantity--;
					deleteItem = false;
				}
				print ("used");
				myPlayer.RenewHealth(item.health);
				GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount -= item.costtouse;
				GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset = 
					new Rect(GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.x,
					         GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.y,
					         ((float)myPlayer.curHealth/(float)myPlayer.maxHealth)*HPbarWidth,
					         GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.height);
			}else{
				deleteItem = false;
			}
			break;
		}
		default:
			break;
		}
		if(deleteItem){
			RemoveItem(item.itemID);
		}
	}

}
