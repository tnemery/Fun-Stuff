using UnityEngine;
using System.Collections;

public class TargetPlayerCam : MonoBehaviour {
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("MainCamera");
	}
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(player.transform);

	}
}
