using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public Texture bgTexture;
	public Texture lifeBar;
	int health;
	int lives;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		health = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerState> ().getHealth();
		lives = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerState> ().getLives ();

		GUI.DrawTexture(new Rect(10, 10, 400, 160), bgTexture);
		GUI.DrawTexture(new Rect(95, 20, (295f*((float)health / 6f)), 50), lifeBar);

		GUI.Label(new Rect (120, 115, 30, 30), "<size=30>"+lives.ToString()+"</size>");
	}
}
