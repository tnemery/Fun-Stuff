using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public Vector3 start;
	public Vector3 end;
	private Vector3 moveTo;
	private float moveSpeed = 0.02f;
	private Transform myPlayer;
	// Use this for initialization
	void Start () {
		myPlayer = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
		start = transform.position;
		print (myPlayer.name);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == start){
			moveTo = end;
		}
		if(transform.position == end){
			moveTo = start;
		}
		transform.position = Vector3.MoveTowards(transform.position,moveTo,moveSpeed);
	}
	/*
	void OnTriggerEnter(Collider other){
		other.transform.parent = transform;
	}
	
	void OnTriggerExit(Collider other){
		other.transform.parent = null;
	}

	void OnCollisionEnter(Collision other){
		if(other.transform.tag == "Player"){
			print ("check");
		}
	}
	*/
}
