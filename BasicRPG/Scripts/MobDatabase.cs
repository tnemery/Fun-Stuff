using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobDatabase : MonoBehaviour {
	public List<MobTypes> myMobs = new List<MobTypes>();
	// Use this for initialization
	void Awake () {
		//myItems.Add (new Item("Crossbow",15,false,false,"Basic ranged weapon",005,100,Item.ItemType.Weapon));
		myMobs.Add(new MobTypes("EnemyWeak",000,1,1,100,10,MobTypes.Type.Weak));
		myMobs.Add(new MobTypes("Enemy",001,10,10,1000,2000,MobTypes.Type.Normal));
	}

}
