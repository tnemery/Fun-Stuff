using UnityEngine;
using System.Collections;

public class TargetEnemy : MonoBehaviour {

	[HideInInspector]
	public string objName = "";
	private GameObject curTarget;
	private GameObject spell;

	public GameObject player;
	private bool spellcast = false;

	private PlayerStats playerRef;
	private float MINDMG = 10.0f;
	private float MAXDMG = 30.0f;
	private float atkspd = 1.0f;
	private bool attacking = false;
	public int goldCost = 0;

	void Start(){
		playerRef = GameObject.Find ("__GameManager").GetComponent<GameEngine>().myPlayer;
		//player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update(){
		if(GameObject.Find ("__GameManager").GetComponent<Inventory>().showInventory == false){
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				
				if(Physics.Raycast(ray,out hit)){
					if(hit.transform.tag == "Enemy"){
						curTarget = hit.transform.gameObject;
						float distance = (Vector3.Distance(this.transform.position,curTarget.transform.position));
						//print ("enemy distance "+distance);
						if(distance <= 18f){
							float angle = 45f;
							if  ( Vector3.Angle(player.transform.forward, curTarget.transform.position - player.transform.position) < angle) {
								//print (playerRef.GetPower());
								if(attacking == false){
									if(GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount < goldCost){
										//sorry not gonna happen
										GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = "Sorry, you don't have enough gold to use your current weapon";
									}else{
										float dmgDone = Random.Range(MINDMG*playerRef.GetPower(),MAXDMG*playerRef.GetPower());
										GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount -= goldCost;
										curTarget.GetComponent<DetectPlayer>().TakingDamage(dmgDone);//Destroy (curTarget);
										attacking = true;
										StartCoroutine(WaitForAttack());
									}
								}

							}
						}
					}
					if(hit.transform.tag == "NPC"){
						curTarget = hit.transform.gameObject;
						float distance = (Vector3.Distance(this.transform.position,curTarget.transform.position));
						//print ("npc distance "+distance);
						if(distance <= 20f){
							print ("NPC name: "+curTarget.name);
							//Destroy (curTarget);
							float angle = 45f;
							if  ( Vector3.Angle(player.transform.forward, curTarget.transform.position - player.transform.position) < angle) {
								GameObject.Find ("__GameManager").GetComponent<GameGUI>().setNPC(curTarget.name);
								GameObject.Find ("__GameManager").GetComponent<GameGUI>().shopOpen = true;
							}
						}
					}
				}
			}
			if (Input.GetMouseButtonDown(1)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if(Physics.Raycast(ray,out hit)){
					if(hit.transform.tag == "Ground"){
						if(!spellcast){
							spellcast = true;
							print (hit.point);
							Vector3 myDir = new Vector3(hit.point.x,0.0f,hit.point.z);
							spell = Instantiate(Resources.Load<GameObject>("Spells/"+"Lightning"),myDir,Quaternion.identity) as GameObject;
							StartCoroutine (DestroySpellPrefab());
						}
					}
				}
			}
		}
	}

	IEnumerator WaitForAttack(){
		yield return new WaitForSeconds(atkspd);
		attacking = false;
	}


	IEnumerator DestroySpellPrefab(){
		yield return new WaitForSeconds(2); //spellCooldown time
		Destroy (GameObject.FindGameObjectWithTag("Spell"));
		spellcast = false;
	}
	
}
