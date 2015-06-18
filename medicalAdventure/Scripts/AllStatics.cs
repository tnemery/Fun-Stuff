using UnityEngine;
using System.Collections;

public class AllStatics : MonoBehaviour {
	public int Score;
	public string[] PlayerVitals;
	public int[] QuestsCompleted;
	public string[] AvailableDiseases;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);
	}

	void Start (){
		//Application.LoadLevel("LocationSelect");
	}

}
