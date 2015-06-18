using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
	public GUISkin title;

	void OnGUI(){
		GUI.skin = title;
		//GUI.Box(new Rect(Screen.width/2 -512, 50, 1024, 102), "");


		}
}
