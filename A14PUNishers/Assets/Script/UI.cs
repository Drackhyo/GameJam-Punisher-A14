using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public Texture bgTexture;
	public Texture lifeBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(10, 10, 400, 160), bgTexture);
		GUI.DrawTexture(new Rect(95, 20, 295, 50), lifeBar);
	}
}
