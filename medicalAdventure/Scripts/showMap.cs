using UnityEngine;
using System.Collections;

public class showMap : MonoBehaviour {
	private bool part1 = false;
	private bool part2 = false;
	private bool part3 = false;
	private bool part4 = false;
	private Vector2[] shape1 = new Vector2[7];
	private Vector2[] shape2 = new Vector2[10];
	private Vector2[] shape3 = new Vector2[12];
	private Vector2[] shape4 = new Vector2[4];
	// Use this for initialization
	void Start () {
		shape1[0] = new Vector2(1.7f,3.0f);
		shape1[1] = new Vector2(2.2f,3.0f);
		shape1[2] = new Vector2(2.4f,3.5f);
		shape1[3] = new Vector2(4.4f,5.6f);
		shape1[4] = new Vector2(4.1f,3.8f);
		shape1[5] = new Vector2(3.0f,2.4f);
		shape1[6] = new Vector2(2.1f,2.5f);

		shape2[0] = new Vector2(0.4f,4.2f);
		shape2[1] = new Vector2(4.7f,3.0f);
		shape2[2] = new Vector2(1.4f,2.9f);
		shape2[3] = new Vector2(2.0f,2.2f);
		shape2[4] = new Vector2(1.8f,1.3f);
		shape2[5] = new Vector2(1.0f,1.2f);
		shape2[6] = new Vector2(0.8f,1.5f);
		shape2[7] = new Vector2(-0.8f,1.8f);
		shape2[8] = new Vector2(-0.6f,2.3f);
		shape2[9] = new Vector2(0.3f,2.7f);

		shape3[0] = new Vector2(-2.3f,5.3f);
		shape3[1] = new Vector2(-0.5f,5.1f);
		shape3[2] = new Vector2(-0.4f,2.7f);
		shape3[3] = new Vector2(-1.3f,2.2f);
		shape3[4] = new Vector2(-1.3f,1.2f);
		shape3[5] = new Vector2(-0.5f,0.8f);
		shape3[6] = new Vector2(-0.7f,0.1f);
		shape3[7] = new Vector2(-1.2f,-1.0f);
		shape3[8] = new Vector2(-2.7f,-1.0f);
		shape3[9] = new Vector2(-3.7f,0.2f);
		shape3[10] = new Vector2(-3.7f,1.3f);
		shape3[11] = new Vector2(-3.1f,1.5f);

		shape4[0] = new Vector2(-0.1f,0.5f);
		shape4[1] = new Vector2(2.8f,-0.2f);
		shape4[2] = new Vector2(1.6f,-2.8f);
		shape4[3] = new Vector2(-0.2f,-1.4f);
	}

	/*
	 * shape1: (1.7,3.0),(2.2,3.0),(2.4,3.5),(4.4,5.6),(4.1,3.8),(3.0,2.4),(2.1,2.5)
	 * shape2: (0.4,4.2),(4.7,3.0),(1.4,2.9),(2.0,2.2),(1.8,1.3),(1.0,1.2),(0.8,1.5),(-0.8,1.8),(-0.6,2.3),(0.3,2.7)
	 * shape3: (-2.3,5.3),(-0.5,5.1),(-0.4,2.7),(-1.3,2.2),(-1.3,1.2),(-0.5,0.8),(-0.7,0.1),(-1.2,-1.0),(-2.7,-1.0),(-3.7,0.2),(-3.7,1.3),(-3.1,1.5)
	 * shape4: (-0.1,0.5),(2.8,-0.2),(1.6-2.8),(-0.2,-1.4)
	 * 
	 * 
	 */


	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100)){
			Debug.DrawLine(ray.origin, hit.point);
			//this.GetComponent<LineRenderer>().SetPosition(0,ray.origin);
			//this.GetComponent<LineRenderer>().SetPosition(1,hit.point);
			if (Poly.ContainsPoint(shape1, hit.point)) {
				part1 = true;
				part2 = false;
				part3 = false;
				part4 = false;
				GameObject.Find ("part1").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find ("part2").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part3").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part4").GetComponent<MeshRenderer>().enabled = false;
			}
			if (Poly.ContainsPoint(shape2, hit.point)) {
				part2 = true;
				part1 = false;
				part3 = false;
				part4 = false;
				GameObject.Find ("part2").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find ("part1").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part3").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part4").GetComponent<MeshRenderer>().enabled = false;
			}
			if (Poly.ContainsPoint(shape3, hit.point)) {
				part3 = true;
				part2 = false;
				part1 = false;
				part4 = false;
				GameObject.Find ("part3").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find ("part2").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part1").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part4").GetComponent<MeshRenderer>().enabled = false;
			}
			if (Poly.ContainsPoint(shape4, hit.point)) {
				part4 = true;
				part2 = false;
				part3 = false;
				part1 = false;
				GameObject.Find ("part4").GetComponent<MeshRenderer>().enabled = true;
				GameObject.Find ("part2").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part3").GetComponent<MeshRenderer>().enabled = false;
				GameObject.Find ("part1").GetComponent<MeshRenderer>().enabled = false;
			}
		}

		if(Input.GetMouseButtonDown(0)){
			if(part1){
				print ("goto map 1");
				Application.LoadLevel("map1");
			}
			if(part2){
				print ("goto map 2");
				Application.LoadLevel("map2");
			}
			if(part3){
				print ("goto map 3");
				Application.LoadLevel("map3");
			}
			if(part4){
				print ("goto map 4");
				Application.LoadLevel("map4");
			}
		}
	}


}
