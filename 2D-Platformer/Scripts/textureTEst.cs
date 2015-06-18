using UnityEngine;
using System.Collections;

public class textureTEst : MonoBehaviour {
	public Texture2D sourceTex;
    public Rect sourceRect;
	public int x;
    static public int y;
    static public int width;
    static public int height;
    public Color[] pix;
    public Texture2D destTex;
	private int[] idleLink = new int[5];
	private int[] runLink = new int[10];
	private int index = 0;
	private float storeTime;
	static private bool idle = true;
	static private bool run = false;
	static private bool attack = false;
	
	// Use this for initialization
	void Start () {
		//courners: 0,0 -> bottom left
		// 0, maxWidth -> top left
		// maxHieght, maxwidth -> top right
		// maxheight, 0 -> bottom right
		
		// y coord to enter: maxWidth - photoshop coord - rectHieght
		storeTime = Time.time;
		idleLink[0] = 24; //coords on the sprite map for x pos
		idleLink[1] = 61;
		idleLink[2] = 98;
		idleLink[3] = 134;
		runLink[0] = 17;
		runLink[1] = 62;
		runLink[2] = 112;
		runLink[3] = 167;
		runLink[4] = 209;
		runLink[5] = 252;
		runLink[6] = 294;
		runLink[7] = 341;
		runLink[8] = 385;
		runLink[9] = 425;
		x = Mathf.FloorToInt(sourceRect.x); //default x and y from inspector
        y = Mathf.FloorToInt(sourceRect.y);
        width = Mathf.FloorToInt(sourceRect.width); //default width and height from inspector that contains the size of the sprite object
        height = Mathf.FloorToInt(sourceRect.height);
        pix = sourceTex.GetPixels(x, y, width, height); //assigns the sprite box texture to a color
        destTex = new Texture2D(width, height); //assigns the new sprite to a texture
        destTex.SetPixels(pix);  //sets the texture to a UV plane
        destTex.Apply(); //applys the UV plane to the game object
        renderer.material.mainTexture = destTex; //renders the new sprite for the user to see.
	}
	
	public static void setBool(string myFlag){ //function called from the game manager to set new sprites
		if(myFlag == "idle"){
			idle = true;
			run = false;
			attack = false;
			width = Mathf.FloorToInt(38);
			height = Mathf.FloorToInt(51);
			y = Mathf.FloorToInt(602);
		}
		if(myFlag == "run"){
			idle = false;
			run = true;
			attack = false;
			width = Mathf.FloorToInt(44);
			height = Mathf.FloorToInt(49);
			y = Mathf.FloorToInt(497);
		}
		if(myFlag == "attack"){
			idle = false;
			run = false;
			attack = true;
			width = Mathf.FloorToInt(68);
			height = Mathf.FloorToInt(45);
			y = Mathf.FloorToInt(269);
		}
	}
	
	// Update is called once per frame
	void Update () { //gets new sprites based on time and bool flags
		if(idle == true){
			if(Time.time - storeTime > .4f){
				storeTime = Time.time;
				if(index >= 4){
					index = 0;	
				}
				x = Mathf.FloorToInt(idleLink[index]);
		        pix = sourceTex.GetPixels(x, y, width, height);
		        destTex = new Texture2D(width, height);
		        destTex.SetPixels(pix);
		        destTex.Apply();
		        renderer.material.mainTexture = destTex;
				index++;
			}
		}
		if(run == true){
			if(Time.time - storeTime > .1f){
				storeTime = Time.time;
				if(index >= 10){
					index = 0;	
				}
				x = Mathf.FloorToInt(runLink[index]);
		        pix = sourceTex.GetPixels(x, y, width, height);
		        destTex = new Texture2D(width, height);
		        destTex.SetPixels(pix);
		        destTex.Apply();
		        renderer.material.mainTexture = destTex;
				index++;
			}
		}
		if(attack == true){
			Debug.Log ("attack");
				x = 501;
		        pix = sourceTex.GetPixels(x, y, width, height);
		        destTex = new Texture2D(width, height);
		        destTex.SetPixels(pix);
		        destTex.Apply();
		        renderer.material.mainTexture = destTex;
				attack = false;
				idle = true;
		}
	}
}


/* sprite maps
 *still pose:
 * 1-  X:24, Y:674-21-51, W:38, H:51
 * 2-  X:61, Y:674-21-51, W:38, H:51
 * 3-  X:98,Y:674-21-51, W:38, H:51
 * 4-  X:134,Y:674-21-51, W:38, H:51
 * 
 * run no weapons:
 * 1- X:17, y:674-128-49, W:44, H:49
 * 2- X:62, y:674-128-49, W:44, H:49
 * 3- X:112, y:674-128-49, W:44, H:49
 * 4- X:167, y:674-128-49, W:44, H:49
 * 5- X:209, y:674-128-49, W:44, H:49
 * 6- X:252, y:674-128-49, W:44, H:49
 * 7- X:294, y:674-128-49, W:44, H:49
 * 8- X:341, y:674-128-49, W:44, H:49
 * 9- X:383, y:674-128-49, W:44, H:49
 * 10- X:425, y:674-128-49, W:44, H:49
 * 
 * attack normal:
 * 1- X: 501, Y:674-360-45, W:68, H:45
 * 
 */