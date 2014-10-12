using UnityEngine;
using System.Collections;

public class GameMusicOnCamera : MonoBehaviour {

	public AudioClip son;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
