using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {
	private bool setMap = false;
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Map")){
			setMap = !setMap;
			this.GetComponent<Camera>().enabled = setMap;
		}
	}
}
