using UnityEngine;
using System.Collections;

public class CharInfo : MonoBehaviour {
	private PlayerStats myplayer;
	private bool showChar = false;

	void Awake(){
		myplayer = GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer;
	}

	void Start(){
		print(myplayer.name);
		print(myplayer.curHealth);
		print(myplayer.maxHealth);
		print(myplayer.power);
		print(myplayer.defense);
	}

	void Update(){
		if(Input.GetButtonDown("CharSheet")){
			showChar = !showChar;
		}
	}

	void OnGUI(){
		if(showChar){
			GUI.Box (new Rect(0,0,300,200),"");
			GUI.Label (new Rect(1,1,250,30),"Name: "+myplayer.name);
			GUI.Label (new Rect(1,50,250,30),"Power: "+myplayer.power);
			GUI.Label (new Rect(1,100,250,30),"Defense: "+myplayer.defense);
			GUI.Label (new Rect(1,150,250,30),"Health: "+myplayer.curHealth+"/"+myplayer.maxHealth);
		}
	}

}
