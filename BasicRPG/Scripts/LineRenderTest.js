#pragma strict
var player:Transform;

function Start () {
	//player = GameObject.FindGameObjectWithTag("laserTarget").transform;
}

function Update () {
    var lineRenderer : LineRenderer = GetComponent(LineRenderer);
    lineRenderer.useWorldSpace = false;
    lineRenderer.SetVertexCount(2);
    var hit : RaycastHit;
    Physics.Raycast(transform.position,transform.forward,hit);
    if(1){
    	print(player.position);
    	lineRenderer.SetPosition(1,-player.position);
    }
    else{
        lineRenderer.SetPosition(1,Vector3(0,0,5000));
    }
}
//266,0,244
 
@script RequireComponent(LineRenderer)