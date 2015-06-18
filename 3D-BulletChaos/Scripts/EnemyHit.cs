using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "PlayerBullet"){
			GameObject.Find ("Main Camera").GetComponent<GameGUI>().score += 1000;
			Destroy(this.gameObject);
			Destroy (other.gameObject);
		}
	}
}
