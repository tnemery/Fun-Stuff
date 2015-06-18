using UnityEngine;
using System.Collections;

public class TempGUI : MonoBehaviour {

	void OnGUI(){
		if(GUI.Button (new Rect(0,0,100,30),"Go Back")){
			Application.LoadLevel("map");
		}
	}
}
