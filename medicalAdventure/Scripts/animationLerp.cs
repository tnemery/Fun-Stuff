using UnityEngine;
using System.Collections;

public class animationLerp : MonoBehaviour {
	public GameObject Player;
	public GameObject Aircraft;

	private bool doOnce = true;

	public Material image1;
	public Material image2;
	public GameObject BackGround;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Player.transform.position = Vector3.Lerp (Player.transform.position,new Vector3(-1.769375f,-0.626514f,-1.866813f),0.01f);

		if(Player.transform.position.x <= -1.719375f){
			Player.GetComponent<MeshRenderer>().enabled = false;
			Aircraft.transform.FindChild ("Stairs").transform.gameObject.SetActive(false);
			Aircraft.transform.FindChild ("Wheels").transform.gameObject.SetActive(false);
			if(doOnce){
				Aircraft.transform.FindChild ("Door").transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
				doOnce = false;
				BackGround.transform.GetComponent<MeshRenderer>().material = image2;
				StartCoroutine(TakeOff());
			}

		}
	}

	IEnumerator TakeOff(){
		yield return new WaitForSeconds(2);
		Application.LoadLevel ("map");
	}

}
