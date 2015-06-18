using UnityEngine;
using System.Collections;

public class rotateCoin : MonoBehaviour {
	private float xRot;
	private float yRot;
	private float zRot;
	// Use this for initialization
	void Start () {
		xRot = 90;
		yRot = 0;
		zRot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		yRot += 2f;
		transform.rotation = Quaternion.Euler (new Vector3(xRot,yRot,zRot));
	}

	void OnTriggerEnter(){
		Destroy (transform.gameObject);
	}
}
