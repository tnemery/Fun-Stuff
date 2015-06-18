using UnityEngine;
using System.Collections;

/// <summary>
/// This Script appears on the trap/box triggers please do not add update functions here
/// </summary>


public class Events : MonoBehaviour {
	/// <summary>
	/// Brainstorming!
	/// Gain hearts
	/// restore hearts
	/// lose hearts
	/// instant death
	/// temporary power
	/// temporary curse
	/// 
	/// </summary>

	private int Roll;
	public CharInfo charScript;


	void Awake(){
		charScript = GameObject.Find("Player").GetComponent<CharInfo>();
	}

	void OnTriggerEnter(Collider other){
		Roll = Random.Range(0,6);
		switch(Roll){
		case 0:
			GainHeart();
			break;
		case 1:
			RestoreHeart();
			break;
		case 2:
			LoseHeart();
			break;
		case 3:
			RemoveHeart ();
			break;
		case 4:
			SuperPower ();
			break;
		case 5:
			Cursed ();
			break;
		default:
			print ("opps looks like something went wrong!");
			break;
		}
		this.transform.collider.enabled = false;
		this.gameObject.SetActive(false);
	}

	//adds a maxheart if under 20 and restores 1 heart
	void GainHeart(){
		print ("gainHeart");
		charScript.AddMaxHeart();
	}

	//restores 1 heart
	void RestoreHeart(){
		print ("restore heart!");
		charScript.RestoreHearts();
	}

	//removes 1 heart
	void LoseHeart(){
		print ("lose heart");
		charScript.RemoveHearts();
	}

	//removes a maxheart
	void RemoveHeart(){
		print ("Lost an available heart");
		charScript.RemoveMaxHeart();
	}

	//adds some random buff
	void SuperPower(){
		print ("I am super man");
		charScript.powerGain();
	}

	//adds a random curse --- lets make this one add a timer, once the timer ends you die
	void Cursed(){
		print ("I feel odd!");
		charScript.Cursed();
	}
}
