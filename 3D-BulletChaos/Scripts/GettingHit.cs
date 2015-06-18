using UnityEngine;
using System.Collections;

public class GettingHit : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "EnemyBullet"){
			Destroy (other.gameObject);
			GameObject.Find ("Main Camera").GetComponent<GameGUI>().TookDamage(33.72f);
		}
		if(other.tag == "PowerUp"){
			Destroy (other.gameObject);
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBullet>().newBullet();
			print ("You got a power up!");
		}
	}
}
