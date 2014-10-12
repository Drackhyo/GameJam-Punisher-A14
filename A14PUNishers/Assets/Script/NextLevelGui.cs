using UnityEngine;
using System.Collections;

public class NextLevelGui : MonoBehaviour {
	public Texture texture;
	public string nextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height), texture);
		if(GUI.Button(new Rect((Screen.width*0.4f), Screen.height*0.4f, (Screen.width*0.2f), Screen.height*0.2f), "Next Level"))
			Application.LoadLevel(nextLevel);

	}
}
