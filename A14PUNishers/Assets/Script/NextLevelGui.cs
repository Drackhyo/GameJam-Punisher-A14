using UnityEngine;
using System.Collections;

public class NextLevelGui : MonoBehaviour {
	public Texture texture;
	public string nextLevel;

	public AudioClip success;

	public Texture _text;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AudioSource>().PlayOneShot(success);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();

	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width,Screen.height), texture);
		GUI.DrawTexture (new Rect ((Screen.width / 2)-(_text.width / 2), (Screen.height / 4)-(_text.height / 2), _text.width, _text.height), _text);
		if(GUI.Button(new Rect((Screen.width*0.4f), Screen.height*0.4f, (Screen.width*0.2f), Screen.height*0.2f), "Next Level"))
			Application.LoadLevel(nextLevel);

	}
}
