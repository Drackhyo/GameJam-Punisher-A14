using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {
	private Transform player;
	private List<Transform> targets;
	private float timeSinceLastShot=0;

	public GameObject BulletPrefab;
	public float shotDelay=2;
	// Use this for initialization
	void Start () {
		targets = new List<Transform>();
		player=GameObject.FindGameObjectWithTag("Player").transform;
		targets.Add(player.transform);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceLastShot+=Time.deltaTime;
		if(timeSinceLastShot>=shotDelay)
		{
			Vector3 spawnpos=transform.position;
			timeSinceLastShot=0;
			if(player.position.x<transform.position.x)
			{

				spawnpos.x-=1;
			}
			else
			{
				spawnpos.x+=0.75f;
			}
			GameObject bulletShot=GameObject.Instantiate(BulletPrefab,spawnpos,transform.rotation)as GameObject;
			Vector2 tempVector= new Vector2((player.position.x - transform.position.x),player.position.y - transform.position.y);
			tempVector.Normalize();
			tempVector=tempVector*8;
			bulletShot.rigidbody2D.velocity= tempVector; 

		}
	}
}
