using UnityEngine;
using System.Collections;
using System.IO;

public class Screenshots : MonoBehaviour {
	private string fileName = "";
	private string path = "./Screenshots/"; //save screenshot here
	private string locateSS = "./paytowin_Data/"; //loaction of screenshot

	void LateUpdate() {
		if (Input.GetKeyDown (KeyCode.Insert)) { //key to take the picture
			fileName = "shot"+Random.Range (0,99999)+".png";
			Application.CaptureScreenshot(fileName); //takes a screenshot
			if(!System.IO.Directory.Exists(path)){ //if no directory for screenshots create it
				System.IO.Directory.CreateDirectory(path);
			}
			StartCoroutine(waiting());
		}
	}


	IEnumerator waiting(){ //wait for screenshot to exist then move it
		yield return new WaitForSeconds(3);
		System.IO.Path.Combine(path,locateSS+fileName);
		System.IO.File.Move(locateSS+fileName,path+fileName);
		//print(System.IO.Path.GetFullPath(path+fileName));
	}
}
