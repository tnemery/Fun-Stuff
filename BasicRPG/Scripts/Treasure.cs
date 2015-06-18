using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {
	private int[] items;
	private bool win = false;
	private bool lose = false;
	private bool ready = false;
	private int temp;
	static private int looted = 0;

	void Start(){
		looted = PlayerPrefs.GetInt("a_loot100");
		items = new int[10];
		items[0] = 0;
		items[1] = 1;
		items[2] = 10;
		items[3] = -1000;
		items[4] = -100000;
		items[5] = 200;
		items[6] = 300;
		items[7] = 1000;
		items[8] = 200000;
		items[9] = 99999999;

	}

	void Update(){
		if(win){
			print ("reroll");
			temp = Random.Range(0,11);
			if(temp == 10){
				win = false;
				lose = true;
			}
			if(temp == 9){
				print ("reroll 2");
				temp = Random.Range(0,11);
				if(temp == 10){
					win = false;
					lose = true;
				}
			}
			win = false;
		}

		if(lose){
			print ("danger");
			temp = Random.Range(0,11);
			if(temp == 9){
				win = true;
				lose = false;
			}
			lose = false;
		}
		if(ready && !win && !lose){
			if(GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount > 200){
				if(temp == 10){
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount -= GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount;
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = "Ouch... maybe you should have not opened that chest, you lost everything, better luck next time.";
					if(PlayerPrefs.GetInt("a_broke") != 1){
						PlayerPrefs.SetInt("a_broke",1);
						GameObject.Find("__GameManager").GetComponent<Achievements>().showbroke = true;
					}
				}else{
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount -= 100;
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount += items[temp];
				}
				if(temp <= 4){
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = "Sorry looks like this chest was hungry, you lose "+Mathf.Abs(items[temp]-100)+" gold.";
				}if(temp > 4 && temp <= 8){
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = "What Luck! You receive "+(items[temp]-100)+" gold.";
				}if(temp == 9){
					GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = "I...I don't believe it.  How did you win this much with a single click, received "+(items[temp]-100)+" gold.";
					if(PlayerPrefs.GetInt("a_jackpot") != 1){
						PlayerPrefs.SetInt("a_jackpot",1);
						GameObject.Find("__GameManager").GetComponent<Achievements>().showjackpot = true;
					}
				}
				Destroy (this.gameObject);
				looted++;
				PlayerPrefs.SetInt ("a_loot100",looted);
				if(PlayerPrefs.GetInt("a_loot100") == 100){
					GameObject.Find("__GameManager").GetComponent<Achievements>().showlooth = true;
				}
			}else{
				GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = "You need some more gold if you want to open me!";
			}

			if(GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount < 0){
				GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount = 0;
			}
			ready = false;
		}
	}

	void OnMouseUp(){
		temp = Random.Range(0,11);
		print ("I clicked a box");


		if(temp == 9){ //really low chance of rolling another 9
			win = true;
		}
		if(temp == 10){ //really low chance of rolling another 9
			lose = true;
		}
		ready = true;
	}
}
