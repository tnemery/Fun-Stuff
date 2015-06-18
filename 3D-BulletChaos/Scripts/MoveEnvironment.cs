using UnityEngine;
using System.Collections;

public class MoveEnvironment : MonoBehaviour {
	private float curX;
	private float curY;
	private float curZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if(curZ >= -500){
			curX = this.transform.position.x;
			curY = this.transform.position.y;
			curZ = this.transform.position.z;
			curZ -= 0.1f;
			this.transform.position = new Vector3(curX,curY,curZ);
		//}
	}
}
