using UnityEngine;
using System.Collections;

public class StopClipping : MonoBehaviour {
	private float distanceOffset = 0;
	private float distance = 10;
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Vector3.down);
		RaycastHit hit;
		
		if(Physics.Raycast(ray,out hit)){
			if(hit.transform.tag == "ground"){
				distanceOffset = distance - hit.distance + 0.8f; 
				distanceOffset = Mathf.Clamp(distanceOffset,0,distance);
				Debug.Log(distanceOffset);
			}
		}else{
			distanceOffset = 0;
		}
	}
}
