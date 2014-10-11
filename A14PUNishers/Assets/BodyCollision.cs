using UnityEngine;
using System.Collections;

public class BodyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){Debug.Log("body, mon");
		if(collider.gameObject.tag == "Player"){

		}
	}
}
