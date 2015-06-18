using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	public Transform myPlayer;
	private float goX;
	private float goY;
	private float goZ;
	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("Player") != null){
			myPlayer = GameObject.FindGameObjectWithTag("Player").transform;
			goX = myPlayer.position.x;
			goY = myPlayer.position.y;
			goZ = myPlayer.position.z;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(myPlayer != null){
			this.transform.position = Vector3.MoveTowards(this.transform.position,new Vector3(goX,goY,goZ),0.3f);
			if(this.transform.position == new Vector3(goX,goY,goZ)){
				Destroy (this.gameObject);
			}
		}
	}
}
