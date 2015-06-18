using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour {
	public GameObject player;
	private float playerX;
	private float playerY;
	private float playerZ;
	private float moveDist = 0.02f;
	// Use this for initialization
	void Start () {
		
	}
	
	
	void updatePosition(){
		player.transform.localPosition =  new Vector3(playerX,playerY,playerZ);	
	}
	// Update is called once per frame
	void Update () {
		playerX = player.transform.localPosition.x;
		playerY = player.transform.localPosition.y;
		playerZ = player.transform.localPosition.z;
		
		if(Input.GetKey(KeyCode.X)){
			textureTEst.setBool("attack");
		}
		if(Input.anyKey == false){
			textureTEst.setBool("idle");
			
		}else if(Input.GetKey(KeyCode.X) == false){
			textureTEst.setBool("run");
			//left right
			if(playerX <= 2.3f && playerX >= -2.3f){
				if(Input.GetKey ("left") || Input.GetKey ("a")){
					playerX += moveDist;
				}else if(Input.GetKey ("right") || Input.GetKey ("d")){
					playerX -= moveDist;
				}
			}else{
				if(Mathf.Ceil(playerX) > 2.3f){
					playerX = 2.29f;
				}
				if(Mathf.Floor(playerX) < -2.3f){
					playerX = -2.29f;	
				}
			}
			//up down
			if(playerY <= 2.2f && playerY >= -2.2f){
				if(Input.GetKey ("down") || Input.GetKey ("s")){
					playerY += moveDist;
				}else if(Input.GetKey ("up") || Input.GetKey ("w")){
					playerY -= moveDist;
				}
			}else{
				if(Mathf.Ceil(playerY) > 2.2f){
					playerY = 2.19f;
				}
				if(Mathf.Floor(playerY) < -2.2f){
					playerY = -2.19f;	
				}
			}
			updatePosition();
		}
	}
	
}
