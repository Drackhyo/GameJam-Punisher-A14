using UnityEngine;
using System.Collections;

public class SpecificActionMenu : MonoBehaviour {

	public string nextLevel = "Quit";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if (nextLevel == "Quit")
			Application.Quit ();
		else
			Application.LoadLevel (nextLevel);
	}
}
