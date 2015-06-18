using UnityEngine;
using System.Collections;

public class rotateGlobe : MonoBehaviour {

	private int rotateSpeed;
	// Use this for initialization
	void Start () {
		rotateSpeed = 10;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}

	/*
	void OnMouseEnter(){
		print ("over");
		rotateSpeed = 0;

	}

	void OnMouseExit(){
		rotateSpeed = 10;
	}

*/
}
