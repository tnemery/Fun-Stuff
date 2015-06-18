using UnityEngine;
using System.Collections;

public class WallShiftLR : MonoBehaviour {
	private int myTimer = 0;
	private float defX;
	private int shift = 5;

	void Awake(){
		defX = transform.position.x;
	}

	// Update is called once per frame
	void FixedUpdate () {
		myTimer++;
		if(myTimer >= 13000){ //6000 is one second, this will trigger every 3 minutes
			int check = Random.Range (0,10);
			if(check < 3){
				//this.transform.RotateAround(this.transform.position,Vector3.up,90f);
				this.transform.position = new Vector3(defX-shift,transform.position.y,transform.position.z);
			}
			if(check > 2 && check < 6 ){
				//this.transform.RotateAround(this.transform.position,Vector3.up,90f);
				this.transform.position = new Vector3(defX,transform.position.y,transform.position.z);
			}else{
				this.transform.position = new Vector3(defX+shift,transform.position.y,transform.position.z);
			}
			myTimer = 0;
		}
	}
}
