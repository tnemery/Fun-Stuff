using UnityEngine;
using System.Collections;

public class MovePlayerBullet : MonoBehaviour {
	private float curX;
	private float curY;
	private float curZ;
	private Transform myPlayer;
	// Use this for initialization
	void Start () {
		myPlayer = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(myPlayer != null){
			curX = this.transform.position.x;
			curY = this.transform.position.y;
			curZ = this.transform.position.z;
			curZ += 0.3f;
			this.transform.position = new Vector3(curX,curY,curZ);
			if(Vector3.Distance(this.transform.position,myPlayer.position) > 100)
				Destroy (this.gameObject);
		}else{
			Destroy (this.gameObject);
		}
	}
}
