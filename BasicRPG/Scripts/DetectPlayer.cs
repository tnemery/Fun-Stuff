using UnityEngine;
using System.Collections;


public class DetectPlayer : MonoBehaviour {
	private Transform target;
	private float moveSpeed = 1.5f;
	private float lerpSpeed = .5f;
	private float rotationSpeed = 10f;
	private float gravity = 20.0F;
	private Quaternion rotation;
	//private CharacterController controller;
	private Vector3 myTransform;

	private bool getOrig = false;
	private bool walkingBack = false;
	private bool myVal = false;
	private Vector3 moveDirection = Vector3.zero;
	public int mobSlot;
	private SpawnMobs myMobs;
	private float mobMaxHPbarScale = 0.7f;
	private int curHP;
	private int maxHP;
	private int defense;
	private int power;
	private int goldGain;

	private MobDatabase database;

	private bool attacking = false;
	private TextMesh myName;
	//private animations aniScript = new animations();

	//animations
	//internal Animator animator;

	void Awake(){
		database = GameObject.Find("_GameMobs").GetComponent<MobDatabase>();
		//myMobs = GameObject.Find ("__GameManager").GetComponent<SpawnMobs>();
		target = GameObject.FindGameObjectWithTag("EnemyTarget").transform;
		myName = this.GetComponentInChildren(typeof(TextMesh)) as TextMesh;
		//print(myName.text);
		//print (database.myMobs.Count);
		for(int j = 0; j < database.myMobs.Count; j++){
			if(database.myMobs[j].name == myName.text){
				maxHP = curHP = database.myMobs[j].health; //myMobs.mobs[mobSlot].health;
				defense = database.myMobs[j].defense;
				power = database.myMobs[j].power;
				goldGain = database.myMobs[j].gold;
				//print (maxHP);
			}
		}
		//maxHP = curHP = 100; //myMobs.mobs[mobSlot].health;
	}


	void getOriginalCoords(){ //mobs spawning spot
		myTransform = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		getOrig = true;
	}


	public void TakingDamage(float dmgTaken){

		curHP -= Mathf.FloorToInt(dmgTaken/defense);
		float ratio = (float)curHP / (float)maxHP;
		GameObject.Find ("__GameManager").GetComponent<GameGUI>().msgText = ("You did "+ Mathf.FloorToInt(dmgTaken/defense)+" damage to "+myName.text+".").ToString();
		//print (ratio);
		if(curHP <= 0){
			Destroy (this.gameObject);
			GameObject.Find ("__GameManager").GetComponent<GameGUI>().goldCount += goldGain;
		}else{
			print (mobMaxHPbarScale*ratio);
			this.transform.FindChild("_HealthBar").transform.localScale = new Vector3((float)(mobMaxHPbarScale*ratio),this.transform.FindChild("_HealthBar").transform.localScale.y,this.transform.FindChild("_HealthBar").transform.localScale.z);
		}
	}


	void Update(){
		if(this.transform.position.y < -2f){
			Destroy(this.gameObject);
		}

		if(target){
			if(Vector3.Distance(this.transform.position,target.transform.position) <= 5.0f){
				gameObject.SendMessage("EnemyMoving",1);
				if(!getOrig){
					getOriginalCoords();
				}
				if(!walkingBack){ //next to the player
					if(Vector3.Distance(this.transform.position,target.transform.position) < 1.5f){
						//enemy attacks!!!!!!!!!!
						if(attacking == false){
							GameObject.Find ("__GameManager").GetComponent<GameEngine>().PlayerDamage(power,myName.text);
							attacking = true;
							StartCoroutine(WaitForAttack());
						}

					}
					if(Vector3.Distance(this.transform.position,target.transform.position) <= 1.0f){
						gameObject.SendMessage("EnemyMoving",2);
						transform.LookAt(target);
					}else{
						transform.LookAt(target);
						float step = moveSpeed * Time.deltaTime;
						transform.position = Vector3.MoveTowards(transform.position,target.position,step);
					}

				}

				if(myTransform != null){
					if(Vector3.Distance(this.transform.position,myTransform) >= 10.0f){
						walkingBack = true;
					}
				}
			}
			if(walkingBack){
				WalkBack();
			}
		}
	}


	IEnumerator WaitForAttack(){
		yield return new WaitForSeconds(1);
		attacking = false;
	}


	void WalkBack(){
		//myVal = true;
		walkingBack = true;
		transform.LookAt (myTransform);
		float step = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position,myTransform,step);
		if(transform.position == myTransform){
			walkingBack = false;
			gameObject.SendMessage("EnemyMoving",2);
		}
		//mob will run back to original spot befor erechasing
	}
	
}
