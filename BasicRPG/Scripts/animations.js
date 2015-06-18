#pragma strict
internal var animator : Animator;
var v : float;
var h : float;
var sprint : float;
var death : int = 0;


function Start () {
	animator = GetComponent(Animator);
}

function Update () {
	if(this.tag == "Player"){
		v = Input.GetAxis("Vertical");
		h = Input.GetAxis("Horizontal");
	
		if(v < 0){
			//GameObject.FindGameObjectWithTag("Player").transform.GetComponent(rotateChar).speed = 0.3;
			transform.GetComponent(rotateChar).speed = 0.3;
		}else if(v > 0){
			//GameObject.FindGameObjectWithTag("Player").transform.GetComponent(rotateChar).speed = 2;
			transform.GetComponent(rotateChar).speed = 2;
		}
	}
}

public function EnemyMoving(move : int){	
	if(move == 1)
		v = 0.3;
	else
		v = 0.0;
		
}

public function EnemyDeath(die : int){	
	death = die;
	print("k?");	
}

function FixedUpdate(){
	if(death == 1){
		animator.SetBool("Death",true);
	}
	animator.SetFloat("Walk",v);
	animator.SetFloat("Turn",h);
	animator.SetFloat("Sprint",sprint);
}

function Sprinting(){
	if(Input.GetButton("Fire1")){
		sprint = 0.2;
	}
	else{
		sprint = 0.0;
	}	
}