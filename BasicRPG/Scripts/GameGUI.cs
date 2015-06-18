using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class GameGUI : MonoBehaviour {

	private Rect windowRect = new Rect(0, 0, 400, 400); //options window
	private string npcname = "";
	private string shopMSG = "";
	[HideInInspector]
	public int goldCount = 0;
	private string[] weaponItemNames = new string[5];
	private int[] weaponItemPrice = new int[5];
	private int[] weaponItemID = new int[5];
	private bool[] weaponItemPurchase = new bool[5];
	private string[] armorItemNames = new string[6];
	private int[] armorItemPrice = new int[6];
	private int[] armorItemID = new int[6];
	private bool[] armorItemPurchase = new bool[6];
	private string[] magicItemNames = new string[5];
	private int[] magicItemPrice = new int[5];
	private int[] magicItemID = new int[5];
	private bool[] magicItemPurchase = new bool[5];
	private string[] consumablesItemNames = new string[1];
	private int[] consumablesItemPrice = new int[1];
	private int[] consumablesItemID = new int[1];
	private bool[] consumablesItemPurchase = new bool[1];
	private string quantity = "1";

	string minutes;
	string seconds;	

	//triggers
	private bool timerRunning = true;
	private bool pauseGame = false;
	private bool invScreen = false;
	public bool startGame = false;
	private bool keyEsc = false;
	[HideInInspector]
	public bool shopOpen = false;

	public GameObject mainPlayer;
	public string msgText = "";
	public GUISkin mainSkin;

	void Awake(){ //initial shop rolls
		goldCount = Random.Range(0,50000000);
		mainPlayer = GameObject.FindGameObjectWithTag("Player");
		//set up weapon shop
		for(int i = 0;i<weaponItemNames.Length;i++){
			int temp = Random.Range(0,GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems.Count);
			//print ("num " +temp);
			if(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop || 
			   GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Weapon){
				i--;
			}else{
				weaponItemNames[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemname;
				weaponItemPrice[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemprice;
				weaponItemPurchase[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itempurchase;
				weaponItemID[i] = temp;
				GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop = true;
			}
			//print (weaponItemNames[i]);
		}


		for(int i = 0;i<armorItemNames.Length;i++){
			int temp = Random.Range(0,GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems.Count);

			if(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop || 
			   (GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Armor &&
			 	GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Feet &&
			 	GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Hands &&
			 	GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Head &&
			 	GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Legs &&
				GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Offhand)){
				i--;
			}else{
				armorItemNames[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemname;
				armorItemPrice[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemprice;
				armorItemPurchase[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itempurchase;
				armorItemID[i] = temp;
				GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop = true;
			}
			//print (weaponItemNames[i]);
		}
	
		//set up magic shop
		for(int i = 0;i<magicItemNames.Length;i++){
			int temp = Random.Range(0,GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems.Count);
			//print ("num " +temp);
			if(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop || 
			   GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Magic){
				i--;
			}else{
				magicItemNames[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemname;
				magicItemPrice[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemprice;
				magicItemPurchase[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itempurchase;
				magicItemID[i] = temp;
				GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop = true;
			}
			//print (weaponItemNames[i]);
		}

		//set up potion shop
		for(int i = 0;i<consumablesItemNames.Length;i++){
			int temp = Random.Range(0,GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems.Count);
			//print ("num " +temp);
			if(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop || 
			   GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemType != Item.ItemType.Consumable){
				i--;
			}else{
				consumablesItemNames[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemname;
				consumablesItemPrice[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itemprice;
				consumablesItemPurchase[i] = GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].itempurchase;
				consumablesItemID[i] = temp;
				GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[temp].inshop = true;
			}
			//print (weaponItemNames[i]);
		}

		//print (weaponItemNames);
	}

	// Update is called once per frame
	void OnGUI () {
		startScreen();
		Gold();
		npcShop();

		GUI.Box (new Rect(Screen.width/2-200,0,400,60),msgText,mainSkin.GetStyle("shoutMessage"));


		//skill slots
		GUI.Box (new Rect(Screen.width/2-200,Screen.height-130,100,100),"LMB");
		GUI.Box (new Rect(Screen.width/2+50,Screen.height-130,100,100),"RMB");

		if(Input.GetKeyDown (KeyCode.Escape)){
			ShowWindow(KeyCode.Escape.ToString());
		}

		if(keyEsc){
			Time.timeScale = 0.0f;
			windowRect = GUILayout.Window(0,windowRect,windowFunc, "Options");
		}

	}


	public void ShowWindow(string key) {
		if(key == "Escape")
			keyEsc = true;
	}
	
	public void HideWindow() {
		keyEsc = false;
		Time.timeScale = 1.0f;
	}


	private void windowFunc(int windowID){
		//print ("got here");
		if (GUILayout.Button("Quit"))
			Application.Quit();
		if (GUILayout.Button("Resume"))
			HideWindow ();
		GUI.DragWindow (new Rect (0, 0, Screen.width, Screen.height));
	}

	private void NPCwindow(int windowID){
		//print ("got here");
		if(windowID == 1){ //weapon shop
			weaponShop();
		}
		if(windowID == 2){ //magic shop
			magicShop();
		}
		if(windowID == 4){ //potion shop
			healthShop();
		}
		if(windowID == 5){ //armor shop
			armorShop();
		}
		if (GUILayout.Button("Done")){
			shopOpen = false;
			Time.timeScale = 1.0f;
			shopMSG = "";
		}
		GUILayout.Label(shopMSG);
		GUI.DragWindow (new Rect (0, 0, Screen.width, Screen.height));
	}


	private bool initConv = true; //local var only to this function
	private void startScreen(){

		if(!startGame){
			Time.timeScale = 0.0f;
			if(initConv){
				if(GUI.Button (new Rect(Screen.width/2,Screen.height/2,150,150),"Start")){
					//GameObject.Find("__GameManager").GetComponent<Conversations>().init();
					startGame = true;
					initConv = false;
				}
			}
		}else{
			Time.timeScale = 1.0f;
		}
	}

	private void Gold(){
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-131,150,30),"Gold: "+goldCount.ToString());
		GUI.Box (new Rect(Screen.width/2-100,Screen.height-80,50,50),"HP");
		GUI.Box (new Rect(Screen.width/2,Screen.height-80,50,50),"MP");

	}

	//set npc name
	public void setNPC(string curName){
		npcname = curName;
	}

	private bool shopGold = true;
	private void npcShop(){
		if(shopOpen){
			if(goldCount > Literals.shopPrice){
				if(shopGold){
					goldCount -= Literals.shopPrice;
					shopGold = false;
				}
				Time.timeScale = 0.0f;
				if(npcname.Substring(4,npcname.Length-4) == "Weapon")
					windowRect = GUILayout.Window(1,windowRect,NPCwindow, (npcname.Substring(4,npcname.Length-4)+" Shop"));
				if(npcname.Substring(4,npcname.Length-4) == "Magic")
					windowRect = GUILayout.Window(2,windowRect,NPCwindow, (npcname.Substring(4,npcname.Length-4)+" Shop"));
				if(npcname.Substring(4,npcname.Length-4) == "Tool")
					windowRect = GUILayout.Window(3,windowRect,NPCwindow, (npcname.Substring(4,npcname.Length-4)+" Shop"));
				if(npcname.Substring(4,npcname.Length-4) == "Health")
					windowRect = GUILayout.Window(4,windowRect,NPCwindow, (npcname.Substring(4,npcname.Length-4)+" Shop"));
				if(npcname.Substring(4,npcname.Length-4) == "Armor")
					windowRect = GUILayout.Window(5,windowRect,NPCwindow, (npcname.Substring(4,npcname.Length-4)+" Shop"));
			}else{
				shopOpen = false;
				shopGold = true;
			}
		}
	}

	//shoplists
	private void weaponShop(){
		//print ("weapon shop");
		GUILayout.Label("Good Day Sir, Welcome to the Weapon Shop!");
		for(int i = 0;i<weaponItemNames.Length;i++){
			GUILayout.BeginHorizontal();
			//print ("i "+i+" wep "+weaponItemNames[i]);
			if(weaponItemPurchase[i] == false){
				GUILayout.Label(weaponItemNames[i]);
				GUILayout.Label("price: "+weaponItemPrice[i].ToString());
				if (GUILayout.Button("Buy")){
					if(goldCount >= weaponItemPrice[i]){
						weaponItemPurchase[i] = true;
						goldCount -= weaponItemPrice[i];
						GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[weaponItemID[i]].itempurchase = true;//weaponPurchaseSet(weaponItemNames[i]);
						GameObject.Find ("__GameManager").GetComponent<Inventory>().AddItem(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[weaponItemID[i]].itemID,1);
						shopMSG = "";
					}else{
						shopMSG = "Not enough gold";
					}
				}
			}
			GUILayout.EndHorizontal();
		}
	}

	private void armorShop(){
		//print ("weapon shop");
		GUILayout.Label("Good Day Sir, Welcome to the Weapon Shop!");
		for(int i = 0;i<armorItemNames.Length;i++){
			GUILayout.BeginHorizontal();
			//print ("i "+i+" wep "+weaponItemNames[i]);
			if(armorItemPurchase[i] == false){
				GUILayout.Label(armorItemNames[i]);
				GUILayout.Label("price: "+armorItemPrice[i].ToString());
				if (GUILayout.Button("Buy")){
					if(goldCount >= armorItemPrice[i]){
						armorItemPurchase[i] = true;
						goldCount -= armorItemPrice[i];
						GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[armorItemID[i]].itempurchase = true;//weaponPurchaseSet(weaponItemNames[i]);
						GameObject.Find ("__GameManager").GetComponent<Inventory>().AddItem(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[armorItemID[i]].itemID,1);
						shopMSG = "";
					}else{
						shopMSG = "Not enough gold";
					}
				}
			}
			GUILayout.EndHorizontal();
		}
	}

	private void magicShop(){
		//print ("weapon shop");
		GUILayout.Label("Good Day Sir, Welcome to the Magic Shop!");
		for(int i = 0;i<magicItemNames.Length;i++){
			GUILayout.BeginHorizontal();
			//print ("i "+i+" wep "+weaponItemNames[i]);
			if(magicItemPurchase[i] == false){
				GUILayout.Label(magicItemNames[i]);
				GUILayout.Label("price: "+magicItemPrice[i].ToString());
				if (GUILayout.Button("Buy")){
					if(goldCount >= magicItemPrice[i]){
						magicItemPurchase[i] = true;
						goldCount -= magicItemPrice[i];
						GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[i].itempurchase = true;//magicPurchaseSet(magicItemNames[i]);
						print ("id "+ GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[magicItemID[i]].itemname);
						GameObject.Find ("__GameManager").GetComponent<Inventory>().AddItem(GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[magicItemID[i]].itemID,1);
						shopMSG = "";
					}else{
						shopMSG = "Not enough gold";
					}
				}
			}
			GUILayout.EndHorizontal();
		}
	}

	private void healthShop(){
		//print ("weapon shop");
		GUILayout.Label("Good Day Sir, Welcome to the Potion Shop!");
		for(int i = 0;i<consumablesItemNames.Length;i++){
			GUILayout.BeginHorizontal();
			//print ("i "+i+" wep "+weaponItemNames[i]);
			if(consumablesItemPurchase[i] == false){
				GUILayout.Label(consumablesItemNames[i]);
				GUILayout.Label("price: "+consumablesItemPrice[i].ToString());
				GUILayout.Label("Quantity:"); quantity = GUILayout.TextField(quantity);
				quantity = Regex.Replace(quantity, @"[^0-9]", "");
				if(quantity.Length > 3){
					quantity = quantity.Substring(0,3);
				}
				if (GUILayout.Button("Buy")){
					if(goldCount >= consumablesItemPrice[i]){
						goldCount -= (consumablesItemPrice[i]*int.Parse(quantity));
						GameObject.Find ("__GameManager").GetComponent<Inventory>().AddItem (GameObject.Find ("__GameManager").GetComponent<itemDatabase>().myItems[consumablesItemID[i]].itemID,int.Parse(quantity));
						quantity = "1";
						shopMSG = "";
					}else{
						shopMSG = "Not enough gold";
					}
				}
			}
			GUILayout.EndHorizontal();
		}
	}

	
	private void gameOver(){

	}

}
