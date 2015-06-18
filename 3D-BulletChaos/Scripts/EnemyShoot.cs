using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public GameObject Bullet;
	public Transform myPlayer;
	private GameObject fireBullet;
	private float fireRate = 0.5f;
	private bool fire = true;
	// Update is called once per frame
	void Update () {
		if(myPlayer != null){
			if(Vector3.Distance(this.transform.position,myPlayer.position) < 100){
				if(this.transform.position.z > myPlayer.position.z){
					if(fire){
						fireBullet = Instantiate(Bullet,this.transform.position,Quaternion.identity) as GameObject;
						fire = false;
						StartCoroutine(firing());
					}
				}

			}
		}
	}

	IEnumerator firing(){
		yield return new WaitForSeconds(fireRate);
		fire = true;
	}
}
