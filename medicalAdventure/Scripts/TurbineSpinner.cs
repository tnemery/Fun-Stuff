using UnityEngine;
using System.Collections;

public class TurbineSpinner : MonoBehaviour {


	void FixedUpdate () {
		this.transform.Rotate(-13f,0f,-13f);
	}
}
