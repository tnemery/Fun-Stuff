using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	public CharInfo charScript;
	public GameObject Player;
	public GameObject StartPos;
	public GameObject[] Levels;
	private int curLevel = 0;
	
	void Awake(){
		charScript = GameObject.Find("Player").GetComponent<CharInfo>();
		Levels[curLevel].transform.position = Vector3.zero;
		Levels[curLevel].SetActive(true);
		for(int y = 1;y<Levels.Length;y++){
			Levels[y].transform.position = new Vector3(0,-50f,0);
		}
	}

	void OnTriggerEnter(Collider other){
		charScript.RemoveCurse();
		if(curLevel < Levels.Length-1){
			Levels[curLevel].transform.position = new Vector3(0,-50f,0);
			Levels[curLevel].SetActive(false);
			Player.transform.position = new Vector3(StartPos.transform.position.x,2f,StartPos.transform.position.z);
			Player.transform.rotation = Quaternion.identity;
			curLevel++;
			print (curLevel+" "+Levels.Length);

			Levels[curLevel].SetActive(true);
			Levels[curLevel].transform.position = Vector3.zero;
		}
		print ("Yey you can go to the next level!");
	}
}
