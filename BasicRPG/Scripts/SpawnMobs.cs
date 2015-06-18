using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMobs : MonoBehaviour {
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject mobprefab;
	public GameObject mobHolder;
	private GameObject mobref;
	public List<MobTypes> mobs = new List<MobTypes>();
	private MobDatabase database;

	private int maxMobs = 300;
	private float boundH = 0.362f;
	private float boundXmin = 1.0f;
	private float boundXmax = 499.0f;
	private float boundZmin = 1.0f;
	private float boundZmax = 499.0f;
	// Use this for initialization
	void Start () {
		database = GameObject.Find("_GameMobs").GetComponent<MobDatabase>();
		for(int i = 0;i<maxMobs;i++){
			int temp = Random.Range (0,2);
			mobs.Add(new MobTypes());
			AddMob (temp);
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(mobHolder.transform.childCount < maxMobs){
			int temp = Random.Range (0,2);
			mobs.Add(new MobTypes());
			AddMob (temp);
		}
	}


	public void AddMob(int mobID){
		for(int i = 0; i < mobs.Count; i++){
			if(mobs[i].name == null){
				for(int j = 0; j < database.myMobs.Count; j++){
					if(database.myMobs[j].mobID == mobID){	
						mobs[i] = database.myMobs[j];
						mobprefab = mobs[i].mobPrefab;
						mobref = Instantiate (mobprefab,new Vector3(Random.Range (boundXmin,boundXmax),boundH,Random.Range(boundZmin,boundZmax)),mobprefab.transform.rotation) as GameObject;	
						mobref.transform.parent = mobHolder.transform;
					}
				}
				break;
			}
		}
	}

}
