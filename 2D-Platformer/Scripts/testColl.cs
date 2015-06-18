using UnityEngine;
using System.Collections;

public class testColl : MonoBehaviour {
	public GameObject player;
	public GameObject town;
	public GameObject zoneMap;
	public Texture texture1;
	public Texture texture2;
	private float radius = 0.05f;
	public Collider[] objectsInRange;
	// Use this for initialization
	void Start () {
		objectsInRange  = Physics.OverlapSphere(player.transform.position, radius);
	}
	
	// Update is called once per frame
	void Update () {
		objectsInRange  = Physics.OverlapSphere(player.transform.position, radius);
		foreach(Collider objects in objectsInRange){
			if(objects.tag == "town"){
				zoneMap.renderer.material.mainTexture = texture2;
			}
		}
		
		if(objectsInRange.Length == 0){
			zoneMap.renderer.material.mainTexture = texture1;
		}
		
	}
	
	
}
