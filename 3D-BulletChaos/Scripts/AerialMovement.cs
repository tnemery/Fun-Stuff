using UnityEngine;
using System.Collections;

public class AerialMovement : MonoBehaviour {
	private float playerX;
	private float playerY;
	private float playerZ;
	private float incAmt = 0.1f;

	private bool goingUp = false;
	private bool goingDown = false;
	private bool goingLeft = false;
	private bool goingRight = false;
	// Use this for initialization
	void Start () {
		playerX = this.transform.position.x;
		playerY = this.transform.position.y;
		playerZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		playerX = this.transform.position.x;
		playerZ = this.transform.position.z;
		if(Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)){
			goingUp = true;
		}

		if(Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)){
			goingDown = true;
		}
		if(Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)){
			goingUp = false;
		}
		
		if(Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow)){
			goingDown = false;
		}

		if(Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)){
			goingLeft = true;
		}
		
		if(Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)){
			goingRight = true;
		}
		if(Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)){
			goingLeft = false;
		}
		
		if(Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)){
			goingRight = false;
		}

		if(goingDown && this.transform.position.y > -5f){
			playerY -= incAmt;
			this.transform.position = new Vector3(playerX,playerY,playerZ);
		}

		if(goingUp  && this.transform.position.y < 5f){
			playerY += incAmt;
			this.transform.position = new Vector3(playerX,playerY,playerZ);
		}

		if(goingLeft && this.transform.position.x > -5f){
			playerX -= incAmt;
			this.transform.position = new Vector3(playerX,playerY,playerZ);
		}

		if(goingRight && this.transform.position.x < 5f){
			playerX += incAmt;
			this.transform.position = new Vector3(playerX,playerY,playerZ);
		}
	}
}
