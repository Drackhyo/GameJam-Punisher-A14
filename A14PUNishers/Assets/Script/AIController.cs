using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
	private Transform player;
	private float timeSinceLastShot=0;
	private bool facingRight=true;
	private float stunnedTime=0.75f;

	float isAttackingTimer=1;
	Vector3 spawnpos;

	public float stunDelay=1;
	public float moveSpeed=4;
	public GameObject BulletPrefab;
	public float shotDelay=2;

	EnemyState enemyState;
	Animator anim;

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").transform;
		enemyState = gameObject.GetComponent<EnemyState>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		stunnedTime += Time.deltaTime;

		Vector3 newPosition = transform.position;
		if(stunnedTime>stunDelay)
		{
			anim.SetBool("IsStunned",false);
			timeSinceLastShot+=Time.deltaTime;
			spawnpos=transform.position;
			if(facingRight)
			{
				newPosition.x += moveSpeed * Time.deltaTime; 
				spawnpos.x+=(collider2D.bounds.size.x/1.5f);
			}
			else
			{
				newPosition.x -= moveSpeed * Time.deltaTime; 
				spawnpos.x-=(collider2D.bounds.size.x/1.5f);
				
			}
			Debug.Log(spawnpos);
			if(timeSinceLastShot>shotDelay && (((player.position.x<=transform.position.x)&&!facingRight)||((player.position.x>=transform.position.x)&&facingRight)))
			{
				timeSinceLastShot=0;
				isAttackingTimer=0;
				anim.SetFloat("TimeAttacking",isAttackingTimer);

			}
			else if(isAttackingTimer<0.5f)
			{
				isAttackingTimer+=Time.deltaTime;
				if(isAttackingTimer>0.25f)
				{
					isAttackingTimer=1;
					anim.SetFloat("TimeAttacking",isAttackingTimer);
					GameObject bulletShot=GameObject.Instantiate(BulletPrefab,spawnpos,transform.rotation)as GameObject;
					Vector2 tempVector= new Vector2((player.position.x - transform.position.x),player.position.y - transform.position.y);
					tempVector.Normalize();
					tempVector=tempVector*8;
					bulletShot.rigidbody2D.velocity= tempVector; 

				}

			}
			else
			{
				transform.position=newPosition;
			}

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
			anim.SetBool("IsStunned",true);
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
