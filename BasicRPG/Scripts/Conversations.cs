using UnityEngine;
using System.Collections;

public class Conversations : MonoBehaviour {
	public Texture2D testpic;
	public GUISkin dialogStyle;


	private string[] allmsgs;
	private bool gameStart = false;

	public string[] dialogs(int talkerID){
		switch(talkerID){
		case 000:
			allmsgs = new string[3];
			allmsgs[0] = "Wait a moment!";
			allmsgs[1] = "Sorry this is really important, you must understand.";
			allmsgs[2] = "I'm kidding, kill things and try to beat me, I'll be waiting.";
			break;
		case 001:
			break;
		default:
			break;
		}



		return allmsgs;
	}

	public void init(){
		gameStart = true;
	}
	
	private int i = 0;
	private string btnText = "Next";
	public void OnGUI(){
		if(gameStart){
			//GUILayout.Box (); use this later right now testing with a box
			dialogs(000);
			GUI.skin = dialogStyle;
			GUI.Box (new Rect(Screen.width/2-100,Screen.height-101,300,100),allmsgs[i]);
			GUI.Box (new Rect(Screen.width/2-200,Screen.height-101,400,100),testpic,allmsgs[i]); //draw picture ontop

			if(i == (allmsgs.Length-1))
				btnText = "Done";
			if(GUI.Button(new Rect(Screen.width/2+100,Screen.height-31,100,30),btnText)){

				if(i == (allmsgs.Length-1)){
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().startGame = true;
					gameStart = false;
				}else
					i++;
			}
		}
	}

	public void convSet(int npcSet){

	}


}
