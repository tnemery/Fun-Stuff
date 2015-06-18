using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	public GUITexture LifeMain;
	public GUITexture LifeDmg;
	public GUITexture PowerBubble;
	public int curPow = 0;
	public GUISkin mySkin;
	public int score = 0;
	private bool dead = false;

	void OnGUI(){
		GUI.Label (new Rect(0,0,100,40),score.ToString(string.Format("000000000",score)));

		GUI.Label(new Rect(Screen.width-60,Screen.height-60,50,50),curPow.ToString(),mySkin.GetStyle("cLabel"));

		if(dead){
			GUI.Label(new Rect(300,300,100,40),"Retry?");
			if(GUI.Button (new Rect(300,350,100,40),"Yes")){
				Application.LoadLevel("Main");
				dead = false;
				LifeMain.pixelInset = new Rect(34.8f,26.1f,337.2f,44.4f);
				LifeDmg.pixelInset = new Rect(34.8f,26.1f,337.2f,44.4f);
			}
			if(GUI.Button (new Rect(400,350,100,40),"No")){
				Application.Quit();
			}
		}
	}


	public void TookDamage(float dmg){
		LifeMain.pixelInset = new Rect(34.8f,26.1f,LifeMain.pixelInset.width - dmg,44.4f);
		StartCoroutine(fadeEffect(dmg));
		if(LifeMain.pixelInset.width <= 0){
			dead = true;
			Destroy (GameObject.FindGameObjectWithTag("Player").gameObject);
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("EnemyBullet")){
				Destroy (go);
			}
		}
		score -= 1000;
		if(score <= 0)
			score = 0;
	}

	IEnumerator fadeEffect(float dmg){
		yield return new WaitForSeconds(1);
		LifeDmg.pixelInset = new Rect(34.8f,26.1f,LifeDmg.pixelInset.width - dmg,44.4f);
	}
}
