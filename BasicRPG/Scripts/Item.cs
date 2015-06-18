using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemname;
	public  int itemprice;
	public bool itempurchase;
	public  bool inshop;
	public Texture2D itempic;
	public string desc;
	public int itemID;
	public int quantity;
	public int costtouse;
	public int power;
	public int defense;
	public int health;
	public ItemType itemType;

	public enum ItemType{
		Weapon,
		Armor,
		Head,
		Hands,
		Feet,
		Legs,
		Offhand,
		Magic,
		Consumable
	}

	public Item(string name, int price, bool purchased, bool shopavail, string mydesc, int ID, int cost, int p, int d, int h, ItemType type){
		itemname = name;
		itemprice = price;
		itempurchase = purchased;
		inshop = shopavail;
		desc = mydesc;
		itemType = type;
		itemID = ID;
		quantity = 0;
		costtouse = cost;
		power = p;
		defense = d;
		health = h;
		itempic = Resources.Load<Texture2D>("Icons/"+name);
	}

	public Item(){

	}
}
