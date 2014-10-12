using UnityEngine;
using System.Collections;

public class PlatformCheckerZ : MonoBehaviour {
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
				transform.parent.gameObject.GetComponent<ZombieScript>().Flip();
			}
			isOnPlatform=false;
			
		}
	}
	void OnTriggerStay2D()
	{
		isOnPlatform=true;
	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag=="Spike")
		{
			transform.parent.gameObject.GetComponent<ZombieScript>().Flip();
		}
	}
}
