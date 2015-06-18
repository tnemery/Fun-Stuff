using UnityEngine;
using System.Collections;

public class SpawnWorld : MonoBehaviour {
	private GameObject[] worldTiles;
	private char[] worldMapping;
	private char[] gTypes;
	public GameObject grasstile;
	public GameObject dirttile;
	public GameObject watertile;
	public GameObject world;
	public GameObject player;

	public GameObject town;
	public GameObject spawnPlayer;
	public GameObject spawnTown;

	private GameObject temp;
	private int row = 50;
	private int col = 50;
	private Vector3 pos = new Vector3(0,0,0);

	private GameObject camScript;
	// Use this for initialization
	void Awake () {
		camScript = GameObject.Find ("minimapCam");
		worldTiles = new GameObject[row*col]; // create world space 5*5
		worldMapping = new char[row*col];
		AddTownMapping();
		gTypes = new char[3];
		gTypes[0] = 'g';
		gTypes[1] = 'd';
		gTypes[2] = 'w';
		SpawnGameWorld();
	}

	void SpawnGameWorld(){
		int count = 0;
		//populate world
		while(count < row*col){
			worldTiles[count] = temp;
			if(worldMapping[count] != 'd'){
				worldMapping[count] = gTypes[Random.Range (0,3)];
			}
			count++;
			//print (count);
		}
		//place on screen
		count = 0;
		/*
		while(count < row*col){
			if(count % row == 0){
				pos.z +=10;
				pos.x = 0;
			}
			if(worldMapping[count] == 'g'){
				temp = Instantiate (grasstile,pos,grasstile.transform.rotation) as GameObject;
			}
			if(worldMapping[count] == 'd'){
				temp = Instantiate (dirttile,pos,dirttile.transform.rotation) as GameObject;
			}
			if(worldMapping[count] == 'w'){
				temp = Instantiate (watertile,pos,watertile.transform.rotation) as GameObject;
			}
			temp.transform.parent = world.transform;
			pos.x += 10;
			count++;
			//print (count);
		}
		*/
		//pos = new Vector3(234,2.72f,240); //change these, right now center of town though
		//temp = Instantiate (player,spawnPlayer.transform.position,player.transform.rotation) as GameObject;
		//print (temp.name);
		//camScript.GetComponent <SmoothFollow>().target = temp.transform;
		//temp = null;
		//temp = Instantiate (town,spawnTown.transform.position,town.transform.rotation) as GameObject;

		/*
		int i;
		for(i = 0;i<5;i++){
			pos = new Vector3(Random.Range(221,260),2.72f,Random.Range(228,271));
			temp = Instantiate (house,pos,house.transform.rotation) as GameObject;
			temp.transform.rotation = Quaternion.Euler(new Vector3(270,Random.Range(0,360),0));
		}
		*/
		//print (worldTiles.Count);
	}

	void AddTownMapping(){
		worldMapping[1122] = 'd'; worldMapping[1172] = 'd'; worldMapping[1222] = 'd'; worldMapping[1272] = 'd'; worldMapping[1322] = 'd';
		worldMapping[1123] = 'd'; worldMapping[1173] = 'd'; worldMapping[1223] = 'd'; worldMapping[1273] = 'd'; worldMapping[1323] = 'd';
		worldMapping[1124] = 'd'; worldMapping[1174] = 'd'; worldMapping[1224] = 'd'; worldMapping[1274] = 'd'; worldMapping[1324] = 'd';
		worldMapping[1125] = 'd'; worldMapping[1175] = 'd'; worldMapping[1225] = 'd'; worldMapping[1275] = 'd'; worldMapping[1325] = 'd';
		worldMapping[1126] = 'd'; worldMapping[1176] = 'd'; worldMapping[1226] = 'd'; worldMapping[1276] = 'd'; worldMapping[1326] = 'd';
	}


	//will pull certain map aspects and predetermine them
	void CreateMap(){

	}

}
