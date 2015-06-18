using UnityEngine;
using System.Collections;

public class locationSelecter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100)){
			if(Input.GetMouseButtonDown(0)){
				if(hit.collider.name == "Africa"){
					Application.LoadLevel("map1");
				}
				if(hit.collider.name == "Brazil"){
					Application.LoadLevel("map2");
				}
				if(hit.collider.name == "Europe"){
					Application.LoadLevel("map3");
				}
				if(hit.collider.name == "Phillipenes"){
					Application.LoadLevel("map4");
				}
			}
		}
	}
}
