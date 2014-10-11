using UnityEngine;

public class PlatformerCharacter2D : MonoBehaviour 
{
	bool facingRight = true;
	
	[SerializeField] float maxSpeed = 10f;
	[SerializeField] float jumpForce = 400f;
	
	[Range(0, 1)]
	
	[SerializeField] bool airControl = false;
	[SerializeField] LayerMask whatIsGround;
	
	Transform groundCheck;
	float groundedRadius = .2f;
	bool grounded = false;
	Transform ceilingCheck;
	float ceilingRadius = .01f;
	Animator anim;
	
	float movementBlockTimer = 5f;
	bool justCollisionned = false;

	public GameObject attack;
	bool isAttacking = false;
	float attackDelay;
	Vector3 spawnPosAttack;
	Quaternion spawnRotAttack;
	
	void Awake()
	{
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		
		if(justCollisionned)
		{
			movementBlockTimer -= Time.deltaTime;
			
			if ( movementBlockTimer <= 0 )
			{
				justCollisionned = false;
				airControl = true;
			}
		}
		else{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
			anim.SetBool("Ground", grounded);
		}
	}
	
	
	public void Move(float move, bool attack, bool jump)
	{
		if(!attack && anim.GetBool("Attack"))
		{
			attack = true;
		}

		if(grounded || airControl)
		{
			if(!isAttacking && attack){
				Attack();
				attackDelay = 0.3f;
				attack = false;
			}
			else{
				attackDelay -= Time.deltaTime;
				if(attackDelay <= 0){
					isAttacking = false;
				}
			}

			anim.SetBool("Attack", attack);
			anim.SetFloat("Speed", Mathf.Abs(move));

			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

			if(move > 0 && !facingRight)
				Flip();
			else if(move < 0 && facingRight)
				Flip();
		}

		if (grounded && jump) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}
	
	
	void Flip ()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if ( collision.gameObject.tag != "Platform" && !justCollisionned )
		{
			justCollisionned = true;
			movementBlockTimer = .3f;
			airControl = false;
			grounded = false;
			KnockBack();
			anim.SetBool("Attack", false);
		}

		if(collision.gameObject.tag != ""){

		}
	}
	
	void KnockBack()
	{
		if ( facingRight )
			rigidbody2D.velocity = new Vector2(-5, 9f);
		else
			rigidbody2D.velocity = new Vector2(5, 9f);
	}


	void Attack(){
		isAttacking = true;
		if(facingRight){
			spawnPosAttack = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
			spawnRotAttack = new Quaternion();
			spawnRotAttack.x = 50;
		}
		else{
			spawnPosAttack = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
			spawnRotAttack = new Quaternion();
			spawnRotAttack.x = 50;
		}
		GameObject slash = GameObject.Instantiate(attack, spawnPosAttack, spawnRotAttack)as GameObject;
	}

}
