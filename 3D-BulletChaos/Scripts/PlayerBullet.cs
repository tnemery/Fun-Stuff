using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	public GameObject standardBullet;
	public GameObject doubleBullet;
	public GameObject trippleBullet;
	public GameObject Destroyer;
	private GameObject myBullet;
	private GameObject thisBullet;
	private bool firing = false;
	private bool fire = true;
	private float fireRate = 0.3f;
	private int type = 0;

	void Start(){
		myBullet = standardBullet;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)){
			firing = true;
		}
		if(Input.GetKeyUp (KeyCode.Space)){
			firing = false;
		}
		if(firing){
			if(fire){
				//thisBullet = Instantiate(myBullet,this.transform.position,Quaternion.identity) as GameObject;
				//GameObject.Find(myBullet.name).transform.position = this.transform.position;
				print (GameObject.Find (myBullet.name).name);
				//thisBullet.transform.position = this.transform.position;
				//thisBullet.transform.rotation = Quaternion.identity;
				fire = false;
				StartCoroutine(firingRate());
			}
		}
	}

	public void newBullet(){
		type++;
		if(type >= 3)
			type = 3;
		switch(type){
		case 1: myBullet = doubleBullet;
			break;
		case 2: myBullet = trippleBullet;
			break;
		case 3: myBullet = Destroyer;
			break;
		default:
			myBullet = standardBullet;
			break;
		}
		GameObject.Find ("Main Camera").GetComponent<GameGUI>().curPow = type;
	}

	IEnumerator firingRate(){
		yield return new WaitForSeconds(fireRate);
		fire = true;
	}
}
