using UnityEngine;
using System.Collections;

public class AutoDestructAnimConversion : MonoBehaviour {

	float delayToDestruction = 0.5f;

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Foreground";
	}
	
	// Update is called once per frame
	void Update () {
		delayToDestruction -= Time.deltaTime;
		if(delayToDestruction <= 0){
			Destroy (gameObject);
		}
	}
}
