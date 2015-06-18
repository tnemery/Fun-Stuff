using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class itemDatabase : MonoBehaviour {
	public List<Item> myItems = new List<Item>();

	void Awake(){
		//weapons
		myItems.Add (new Item("Wooden Sword",1,false,false,"This might break on your first use",001,3,3,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Iron Sword",40,false,false,"Standard issue knight weapon",002,10,10,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Ice Sword",350,false,false,"Freezes enemies on impact",003,100,50,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Fire Sword",300,false,false,"Burns to the touch",004,100,50,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Crossbow",15,false,false,"Basic ranged weapon",005,90,5,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Whip",20,false,false,"I hear you want to be a tamer",006,90,6,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Behemith Axe",5000,false,false,"Sharp enough to cut through anything",007,100000,200,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Crusher",1000,false,false,"This blunt weapon is good for smashing",008,70000,70,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Ancient Edge",10000000,false,false,"Oldest weapon found, results may vary",009,900000,900,0,0,Item.ItemType.Weapon));
		myItems.Add (new Item("Godslayer",12000000,false,false,"This weapon does not even exist",010,1000000,1000,1000,1000,Item.ItemType.Weapon));
		myItems.Add (new Item("UltimateDestroyer",4000,false,false,"Used by a legendary hero to bring down the most evil demons of hell",011,100000,100,0,0,Item.ItemType.Weapon));

		//Armor all types
		myItems.Add (new Item("Basic Shoes",50,false,false,"Basic Adventurer Gear",300,100,0,1,1,Item.ItemType.Feet));
		myItems.Add (new Item("Basic Gloves",50,false,false,"Basic Adventurer Gear",301,100,0,1,1,Item.ItemType.Hands));
		myItems.Add (new Item("Basic Pants",50,false,false,"Basic Adventurer Gear",302,100,0,1,1,Item.ItemType.Legs));
		myItems.Add (new Item("Basic Shield",50,false,false,"Basic Adventurer Gear",303,100,0,1,1,Item.ItemType.Offhand));
		myItems.Add (new Item("Basic Shirt",50,false,false,"Basic Adventurer Gear",304,100,0,1,1,Item.ItemType.Armor));
		myItems.Add (new Item("Basic Hat",50,false,false,"Basic Adventurer Gear",305,100,0,1,1,Item.ItemType.Head));
		//magic
		myItems.Add (new Item("Fire",10,false,false,"Fire burns at your fingertips",100,100,10,10,10,Item.ItemType.Magic));
		myItems.Add (new Item("Ice",10,false,false,"Freeze your foes in place",101,100,10,10,10,Item.ItemType.Magic));
		myItems.Add (new Item("Lightning",10,false,false,"Electrical discharge",102,100,10,10,10,Item.ItemType.Magic));
		myItems.Add (new Item("Holy",10,false,false,"Might work better on undead",103,100,10,10,10,Item.ItemType.Magic));
		myItems.Add (new Item("Flare",10,false,false,"Blinding light",104,100,10,10,10,Item.ItemType.Magic));
		myItems.Add (new Item("Quake",10,false,false,"Control the Earth beneath you",105,100,10,10,10,Item.ItemType.Magic));
		myItems.Add (new Item("Implode",1000000,false,false,"Nothing Remains",106,100,10,10,10,Item.ItemType.Magic));
		//consumables
		myItems.Add (new Item("Potion",1,false,false,"Restore some health",200,200,0,0,50,Item.ItemType.Consumable));


	}

}
