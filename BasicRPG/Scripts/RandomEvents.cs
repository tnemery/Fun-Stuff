using UnityEngine;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	public string[] MyEventTitles;
	private int MAXTIME = 600;
	private int MINTIME = 300;
	private int WaitTime;
	private string curEvent = "";

	void Awake(){
		WaitTime = Random.Range(MINTIME,MAXTIME);
		print ("waitTime: "+WaitTime);
		StartCoroutine (EventTime());
	}

	IEnumerator EventTime(){
		yield return new WaitForSeconds(WaitTime);
		curEvent = MyEventTitles[Random.Range (0,MyEventTitles.Length)];
		print ("Our event is: "+ curEvent);
		GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = curEvent;

	}
}
