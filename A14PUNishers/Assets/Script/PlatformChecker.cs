using UnityEngine;
using System.Collections;

public class PlatformChecker : MonoBehaviour {
	private bool isOnPlatform=true;
	private float counter=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		counter+=Time.deltaTime;
		if (counter>=0.1f)
		{
			counter=0;
			if(!isOnPlatform)
				{
					transform.parent.gameObject.GetComponent<AIController>().Flip();
				}
				isOnPlatform=false;
	
		}
	}
	void OnTriggerStay2D()
	{
		isOnPlatform=true;
	}
}
