using UnityEngine;
using System.Collections;

public class rotateSkybox : MonoBehaviour {
	private float rotateSpeed = 0.5f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,rotateSpeed*Time.deltaTime,0);
	}
}
