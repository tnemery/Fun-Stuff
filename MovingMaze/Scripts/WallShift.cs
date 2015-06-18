using UnityEngine;
using System.Collections;

public class WallShift : MonoBehaviour {
	private int myTimer = 0;
	private float defZ;
	private int shift = 5;

	void Awake(){
		defZ = transform.position.z;
	}

	// Update is called once per frame
	void FixedUpdate () {
		myTimer++;
		if(myTimer >= 13000){ //6000 is one second, this will trigger every 3 minutes
			int check = Random.Range (0,10);
			if(check < 3){
				//this.transform.RotateAround(this.transform.position,Vector3.up,90f);
				this.transform.position = new Vector3(transform.position.x,transform.position.y,defZ-shift);
			}
			if(check > 2 && check < 6 ){
				//this.transform.RotateAround(this.transform.position,Vector3.up,90f);
				this.transform.position = new Vector3(transform.position.x,transform.position.y,defZ);
			}else{
				this.transform.position = new Vector3(transform.position.x,transform.position.y,defZ+shift);
			}
			myTimer = 0;
		}
	}
}
