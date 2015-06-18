using UnityEngine;
using System.Collections;

//[System.Serializable]
public class Literals {
	//this will have all of the variables that I will be using that are not modified in the code
	//public static Rect slotRect = new Rect(x * 60, y * 60,50,50);
	public static int slotsX = 7,slotsY = 5;
	public static int equipSlots = 7;
	public static int mouseOffset = 30;
	public static float invOffset = Screen.width/30.8f;
	public static float gridSize = Screen.width/30.8f;
	public static float gridWidth = gridSize*slotsX;
	public static float gridHeight = gridSize*slotsY;
	public static int shopPrice = 100;
	public static int invPrice = 100;
	//public static Rect curDrag = new Rect(Event.current.mousePosition.x-25,Event.current.mousePosition.y-25,gridSize,gridSize);

}
