using UnityEngine;
using System.Collections;

public class AttackAutoDestroy : MonoBehaviour {

	float delayToDestruction = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		delayToDestruction -= Time.deltaTime;
		if(delayToDestruction <= 0){
			Destroy (gameObject);
		}
	}
}
