using UnityEngine;
using System.Collections;

public class MobTypes {
	public string name;
	public int power;
	public int defense;
	public int health;
	public int mobID;
	public int gold;
	public Type type;
	public GameObject mobPrefab;

	public enum Type{
		Weak,
		Normal,
		Strong,
		Boss
	}

	public MobTypes(string n, int id, int p, int d, int h, int gAmt, Type t){
		name = n;
		mobID = id;
		power = p;
		defense = d;
		health = h;
		type = t;
		gold = gAmt;
		mobPrefab = Resources.Load<GameObject>("Mobs/"+name);
	}

	public MobTypes(){

	}

}
