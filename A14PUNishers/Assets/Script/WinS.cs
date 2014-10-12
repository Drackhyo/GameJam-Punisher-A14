using UnityEngine;
using System.Collections;

public class WinS : MonoBehaviour {
	public Texture texture;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		//GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height), texture);
		if(GUI.Button(new Rect((Screen.width*0.4f), Screen.height*0.8f, (Screen.width*0.2f), Screen.height*0.2f), "Back to Main Menu"))
			Application.LoadLevel("MainMenu");
	}
}
