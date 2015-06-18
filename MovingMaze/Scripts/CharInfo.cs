using UnityEngine;
using System.Collections;

public class CharInfo : MonoBehaviour {
	private int MaxHearts = 3; //defualt = 3
	public GameObject[] myHearts;
	private int curMaxEnabled = 2; //spot 2 is the max enabled
	public int powerUps = 0;
	public GameObject[] powerMeter;
	private bool DoomCounter = false;
	private float myTimer = 0;
	private float timeLeft = 0;
	public GameObject[] MazeSelect;

	void Update(){

		if(Input.GetKeyDown (KeyCode.Escape)){
			Application.Quit();
		}
		
		if(DoomCounter){
			timeLeft = myTimer - Time.time;
		}

		if(powerUps > 0){
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				
				if(Physics.Raycast(ray,out hit)){
					if(hit.transform.tag == "Wall"){
						hit.transform.collider.enabled = false;
						hit.transform.gameObject.SetActive(false);
						powerUps--;
						PowerDisplay();
					}
				}
			}
		}

		if(MaxHearts == 0 || curMaxEnabled < 0){

			print ("GAME OVER");
		}
	}


	private void OnGUI(){
		if(DoomCounter){
			GUI.Box(new Rect(0,0,200,30),"Get out or Die in: "+Mathf.RoundToInt( timeLeft ).ToString());
			if(Mathf.RoundToInt( timeLeft ) <= 0){
				timeLeft = 0;
				print ("GAME OVER");
			}
		}

	}

	private void PowerDisplay(){
		for(int i = 0; i< 12;i++){
			powerMeter[i].GetComponent<SpriteRenderer>().enabled = false;
		}
		powerMeter[powerUps].GetComponent<SpriteRenderer>().enabled = true;
	}


	public int ReturnMaxHearts(){
		//myHearts[7].GetComponent<SpriteRenderer>().enabled = true;
		return MaxHearts;
	}

	public void AddMaxHeart(){
		if(MaxHearts < 20){
			MaxHearts++;
			RestoreHearts ();
		}
	}

	public void RestoreHearts(){
		if(curMaxEnabled >= 0 && curMaxEnabled <= 20 && curMaxEnabled < (MaxHearts-1)){
			curMaxEnabled++;
			for(int i = 0;i<MaxHearts;i++){
				if(myHearts[i].GetComponent<SpriteRenderer>().enabled){

				}else{
					myHearts[i].GetComponent<SpriteRenderer>().enabled = true;
					break;
				}
			}
		}
	}

	public void RemoveMaxHeart(){
		if(MaxHearts > 0){
			MaxHearts--;
			if(curMaxEnabled == MaxHearts){
				RemoveHearts ();
			}
		}
	}

	public void RemoveHearts(){
		if(curMaxEnabled >= 0 && curMaxEnabled <= 20){
			myHearts[curMaxEnabled].GetComponent<SpriteRenderer>().enabled = false;
				
			curMaxEnabled--;
		}
	}

	public void powerGain(){
		if(powerUps < 11){
			powerUps++;
			PowerDisplay();
		}
	}

	public void Cursed(){
		if(DoomCounter == false){
			DoomCounter = true;
			myTimer = Time.time + 240;
		}
	}

	public void RemoveCurse(){
		if(DoomCounter){
			DoomCounter = false;
		}
	}

}
