using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour {
	public bool showjackpot = false;
	public bool showbroke = false;
	public bool showlooth = false;


	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
	}

	void OnGUI(){
		if(showjackpot){
			GUI.Box (new Rect(Screen.width/2-200,Screen.height/2-15,400,30),"You have earned the Acheivement: JackPot");
		}
		if(showbroke){
			GUI.Box (new Rect(Screen.width/2-200,Screen.height/2-15,400,30),"You have earned the Acheivement: Bad Day");
		}
		if(showlooth){
			GUI.Box (new Rect(Screen.width/2-200,Screen.height/2-15,400,30),"You have earned the Acheivement: Loot 100 chests");
		}
	}


	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("a_jackpot") == 1 && showjackpot){
			print("JackPot");
			StartCoroutine(DisplayAch());
		}
		if(PlayerPrefs.GetInt("a_broke") == 1 && showbroke){
			print("Cursed");
			StartCoroutine(DisplayAch());
		}
		if(PlayerPrefs.GetInt("a_loot100") >= 100 && showlooth){
			print("Thats a lot of loot!");
			StartCoroutine(DisplayAch());
		}
	}

	IEnumerator DisplayAch(){
		yield return new WaitForSeconds(2);
		showjackpot = false;
     	showbroke = false;
     	showlooth = false;
	}
}
