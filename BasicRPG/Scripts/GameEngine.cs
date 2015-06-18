using UnityEngine;
using System.Collections;

public class GameEngine : MonoBehaviour {
	public PlayerStats myPlayer = new PlayerStats("Darby",1,1,100);
	private itemDatabase database;
	private string currentWeapon = ""; // item to swap
	private string currentHands = ""; // item to swap
	private string currentHead = ""; // item to swap
	private string currentFeet = ""; // item to swap
	private string currentOffhand = ""; // item to swap
	private string currentArmor = ""; // item to swap
	private float HPbarWidth = 100;

	void Start(){
		database = GameObject.Find("__GameManager").GetComponent<itemDatabase>();
	}

	public void PlayerDamage(float dmgTaken,string enemyName){
		print (dmgTaken+" "+myPlayer.defense);
		myPlayer.curHealth -= (dmgTaken/(float)myPlayer.defense);
		print ((float)myPlayer.curHealth+" "+(float)myPlayer.maxHealth);
		GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = (enemyName+" has dealt "+ Mathf.FloorToInt(dmgTaken/(float)myPlayer.defense)+" damage to "+myPlayer.name+".").ToString();

		if(myPlayer.GetHealth() > 0){
			GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset = 
				new Rect(GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.x,
			         	GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.y,
			       		((float)myPlayer.curHealth/(float)myPlayer.maxHealth)*HPbarWidth,
			         	GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.height);
		}
		if(myPlayer.GetHealth() <= 0){
			GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset = 
				new Rect(GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.x,
				         GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.y,
				         0,
				         GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<GUITexture>().pixelInset.height);
			print ("dude you died");
		}

	}


	//weapon
	public void showWeapon(string gear){
		if(currentWeapon != ""){
			if(GameObject.Find (currentWeapon).transform.childCount > 0){
				Renderer[] renderers = GameObject.Find (currentWeapon).GetComponentsInChildren<Renderer>();
				foreach (Renderer r in renderers)
				{
					r.enabled = false;
				}
			}else{
				GameObject.Find(currentWeapon).renderer.enabled = false;
			}
			GameObject.Find(currentWeapon).GetComponent<ParticleRenderer>().enabled = false;
		}
		if(GameObject.Find(gear) != null){
			GameObject.Find(gear).GetComponent<ParticleRenderer>().enabled = true; //.particleEmitter.enabled = true;
			if(GameObject.Find (gear).transform.childCount > 0){
				Renderer[] renderers = GameObject.Find (gear).GetComponentsInChildren<Renderer>();
				foreach (Renderer r in renderers)
				{
					r.enabled = true;
				}
			}else{
				GameObject.Find(gear).renderer.enabled = true;
			}
			currentWeapon = gear;
		}
	}

	//hands
	public void showHands(string gear){

		if(currentHands != ""){
			GameObject.Find(currentHands).renderer.enabled = false;
			GameObject.Find(currentHands).GetComponent<ParticleRenderer>().enabled = false;
		}
		if(GameObject.Find(gear) != null){
			GameObject.Find(gear).renderer.enabled = true;
			GameObject.Find(gear).GetComponent<ParticleRenderer>().enabled = true; //.particleEmitter.enabled = true;
			currentHands = gear;
		}
	}

	//head
	public void showHead(string gear){
		if(currentHead != ""){
			GameObject.Find(currentHead).renderer.enabled = false;
			GameObject.Find(currentHead).GetComponent<ParticleRenderer>().enabled = false;
		}
		if(GameObject.Find(gear) != null){
			GameObject.Find(gear).renderer.enabled = true;
			GameObject.Find(gear).GetComponent<ParticleRenderer>().enabled = true; //.particleEmitter.enabled = true;
			currentHead = gear;
		}
	}

	//feet
	public void showFeet(string gear){
		if(currentFeet != ""){
			GameObject.Find(currentFeet).renderer.enabled = false;
			GameObject.Find(currentFeet).GetComponent<ParticleRenderer>().enabled = false;
		}
		if(GameObject.Find(gear) != null){
			GameObject.Find(gear).renderer.enabled = true;
			GameObject.Find(gear).GetComponent<ParticleRenderer>().enabled = true; //.particleEmitter.enabled = true;
			currentFeet = gear;
		}
	}

	//offHand
	public void showOffhand(string gear){
		if(currentOffhand != ""){
			GameObject.Find(currentOffhand).renderer.enabled = false;
			GameObject.Find(currentOffhand).GetComponent<ParticleRenderer>().enabled = false;
		}
		if(GameObject.Find(gear) != null){
			GameObject.Find(gear).renderer.enabled = true;
			GameObject.Find(gear).GetComponent<ParticleRenderer>().enabled = true; //.particleEmitter.enabled = true;
			currentOffhand = gear;
		}
	}

	//armor
	public void showArmor(string gear){
		if(currentArmor != ""){
			GameObject.Find(currentArmor).renderer.enabled = false;
			GameObject.Find(currentArmor).GetComponent<ParticleRenderer>().enabled = false;
		}
		if(GameObject.Find(gear) != null){
			GameObject.Find(gear).renderer.enabled = true;
			GameObject.Find(gear).GetComponent<ParticleRenderer>().enabled = true; //.particleEmitter.enabled = true;
			currentArmor = gear;
		}
	}

}
