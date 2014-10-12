using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
	private Transform player;
	private float timeSinceLastShot=0;
	private bool facingRight=true;
	private float stunnedTime=0.75f;

	float isAttackingTimer=1;
	Vector3 spawnpos;
	bool hasShot=false;

	public float stunDelay=1;
	public float moveSpeed=4;
	public GameObject BulletPrefab;
	public float shotDelay=2;

	EnemyState enemyState;
	Animator anim;

	// Use this for initialization
	void Start () {
		player= GameObject.FindGameObjectWithTag("Player").transform;
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
				spawnpos.x+=1;
			}
			else
			{
				newPosition.x -= moveSpeed * Time.deltaTime; 
				spawnpos.x-=1;
				
			}
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
					anim.SetFloat("TimeAttacking",isAttackingTimer);
					if(hasShot==false)
						{
						GameObject bulletShot=GameObject.Instantiate(BulletPrefab,spawnpos,transform.rotation)as GameObject;
						Vector2 tempVector= new Vector2((player.position.x - transform.position.x),player.position.y - transform.position.y);
						tempVector.Normalize();
						tempVector=tempVector*8;
						bulletShot.rigidbody2D.velocity= tempVector;
						hasShot=true;
					}
				}
				else if(isAttackingTimer>0.35f)
				{
					isAttackingTimer=1;
					hasShot=false;
				}


			}
			else
			{
				hasShot=false;
				transform.position=newPosition;
			}

		}

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{

		if ( collision.gameObject.tag != "Platform" && collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" )
		{
			KnockBack(1);
		}
		else if(collision.gameObject.tag == "Player")
			KnockBack();
	}

	public void KnockBack(int damage=0)
	{
		if(stunnedTime>=stunDelay)
		{
			enemyState.TakeDamage(damage);
			if ( facingRight )
				rigidbody2D.velocity = new Vector2(-3, 3f);
			else
				rigidbody2D.velocity = new Vector2(3, 3f);

			stunnedTime=0;
			anim.SetBool("IsStunned",true);
		}
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
