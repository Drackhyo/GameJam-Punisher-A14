using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {
	private Transform player;
	private List<Transform> targets;
	private float timeSinceLastShot=0;
	private bool facingRight=true;

	public float moveSpeed=4;
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
		Vector3 newPosition = transform.position;
		if(facingRight)
		{
			newPosition.x += moveSpeed * Time.deltaTime; 
			Vector3 spawnpos=transform.position;
			spawnpos.x+=(collider2D.bounds.size.x/1.5f);
			if(timeSinceLastShot>=shotDelay)
			{
				if((player.position.x>=transform.position.x))
				{
					timeSinceLastShot=0;
					GameObject bulletShot=GameObject.Instantiate(BulletPrefab,spawnpos,transform.rotation)as GameObject;
					Vector2 tempVector= new Vector2((player.position.x - transform.position.x),player.position.y - transform.position.y);
					tempVector.Normalize();
					tempVector=tempVector*8;
					bulletShot.rigidbody2D.velocity= tempVector; 
				}
			}
		}
		else
		{
			newPosition.x -= moveSpeed * Time.deltaTime; 
			Vector3 spawnpos=transform.position;
			spawnpos.x-=(collider2D.bounds.size.x/1.5f);
			if(timeSinceLastShot>=shotDelay)
			{
				if((player.position.x<=transform.position.x))
				{
					timeSinceLastShot=0;
					GameObject bulletShot=GameObject.Instantiate(BulletPrefab,spawnpos,transform.rotation)as GameObject;
					Vector2 tempVector= new Vector2((player.position.x - transform.position.x),player.position.y - transform.position.y);
					tempVector.Normalize();
					tempVector=tempVector*8;
					bulletShot.rigidbody2D.velocity= tempVector; 
				}
			}
		}
		transform.position = newPosition;

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.gameObject.name);
		if(collision.gameObject.layer!=0)
		{
			if(facingRight)
				transform.position=new Vector3(transform.position.x-1,transform.position.y,0);
			else
				transform.position=new Vector3(transform.position.x+1,transform.position.y,0);
		}
	}
	public void Flip ()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
