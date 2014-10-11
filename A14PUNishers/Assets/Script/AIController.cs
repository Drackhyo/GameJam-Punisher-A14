using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController : MonoBehaviour {
	private Transform player;
	private List<Transform> targets;
	private float timeSinceLastShot=0;
	private bool facingRight=true;
	private float stunnedTime=0;

	public float stunDelay=1;
	public float moveSpeed=4;
	public GameObject BulletPrefab;
	public float shotDelay=2;

	EnemyState enemyState;

	// Use this for initialization
	void Start () {
		targets = new List<Transform>();
		player=GameObject.FindGameObjectWithTag("Player").transform;
		targets.Add(player.transform);
		enemyState = gameObject.GetComponent<EnemyState>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		stunnedTime += Time.deltaTime;
		timeSinceLastShot+=Time.deltaTime;
		Vector3 newPosition = transform.position;
		if(stunnedTime>stunDelay)
		{
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

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(collision.gameObject.name);

		if ( collision.gameObject.tag != "Platform" && collision.gameObject.tag != "Bullet" )
		{
			KnockBack();
			enemyState.TakeDamage(1);
			stunnedTime=0;
		}
	}

	void KnockBack()
	{
		if ( facingRight )
			rigidbody2D.velocity = new Vector2(-3, 3f);
		else
			rigidbody2D.velocity = new Vector2(3, 3f);
	}

	public void Flip ()
	{
		if(stunnedTime>stunDelay)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
