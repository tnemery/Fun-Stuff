using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {
	public GameObject myTree;
	public GameObject myBush;
	public GameObject Treasure;
	public GameObject TreasureContainer;
	public GameObject shrubContainer;
	private GameObject newObj;
	private int maxTree = 300;
	private int maxTreasure = 100;
	// Use this for initialization
	void Start () {
		for(int i = 0; i<maxTree;i++){
			Vector3 myPoint = new Vector3(Random.Range (0,500),15.0f,Random.Range (0,500));
			newObj = Instantiate(myTree,myPoint,myTree.transform.rotation) as GameObject;
			newObj.transform.parent = shrubContainer.transform;
		}

		for(int i = 0; i<maxTree;i++){
			Vector3 myPoint = new Vector3(Random.Range (0,500),15.0f,Random.Range (0,500));
			newObj = Instantiate(myBush,myPoint,myBush.transform.rotation) as GameObject;
			newObj.transform.parent = shrubContainer.transform;
		}

		for(int i = 0; i<maxTreasure;i++){
			Vector3 myPoint = new Vector3(Random.Range (0,500),15.0f,Random.Range (0,500));
			newObj = Instantiate(Treasure,myPoint,Treasure.transform.rotation) as GameObject;
			newObj.transform.parent = TreasureContainer.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
