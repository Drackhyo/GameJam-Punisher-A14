using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float timeToExpire=7;
	private float timeElapsed=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed+=Time.deltaTime;
		if(timeElapsed>timeToExpire)
		{
			Destroy (gameObject);
		}
	
	}
	void OnCollisionEnter2D()
	{
		Destroy (gameObject);
	}
}
