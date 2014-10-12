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
	float attackEndDelay = 0f;
	Vector3 spawnPosAttack;
	Quaternion spawnRotAttack;

	float deathDelay = 0.7f;
	public bool isDying = false;

	bool isConverting = false;
	public GameObject zombie;
	public GameObject animConversion;

	float comboTimer = 0f;
	int comboCount = 1;
	
	void Awake()
	{
		groundCheck = transform.Find("GroundCheck");
		ceilingCheck = transform.Find("CeilingCheck");
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		if(comboTimer > 0)
			comboTimer -= Time.deltaTime;

		if(!isDying){
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

			anim.SetBool("IsHurt", justCollisionned);
		}
		else{
			deathDelay -= Time.deltaTime;
			anim.SetBool("IsDead", true);

			if(deathDelay <= 0){
				deathDelay = 0.7f;
				isDying = false;
				gameObject.GetComponent<PlayerState>().Dies();
				anim.SetBool("IsDead", false);
			}
		}
	}
	
	
	public void Move(float move, bool attack, bool jump, bool convert)
	{
		if(!isConverting){
			if(!isAttacking && attack && attackEndDelay <= 0){
				if (comboTimer > 0)
					comboCount++;
				else
					comboCount = 1;

				if (comboCount > 3)
					comboCount = 1;

				Attack(comboCount);
				attackDelay = 0.4f;
				comboTimer = 1f;
				attack = false;
			}

			else if(isAttacking){
				attackDelay -= Time.deltaTime;

				if(attackDelay <= 0){
					isAttacking = false;
					attackEndDelay = 0.3f;
				}
			}

			else{

				if(attackEndDelay >= 0){
					attackEndDelay -= Time.deltaTime;
				}

				if(grounded || airControl)
				{
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

				if(convert){
					Conversion();
				}
			}
			anim.SetBool("Attack", isAttacking);
		}
	}


	void Conversion(){
		foreach (GameObject body in GameObject.FindGameObjectsWithTag("Body")){

			if((body.transform.position-transform.position).magnitude <= 2){

				Instantiate(zombie, transform.position, new Quaternion(0,0,0,0));
				
				Vector3 newPosPlayer = new Vector3(body.transform.position.x, transform.position.y, transform.position.z);
				gameObject.transform.position = newPosPlayer;
				Destroy(body);
				GameObject convertEffect=Instantiate(animConversion, transform.position, transform.localRotation)as GameObject;
				convertEffect.transform.Rotate(new Vector3(1,0,0),270f);
				gameObject.GetComponent<PlayerState>().ReplenishHealth();
				//isConverting = true;
				break;
			}

		};
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

		if ( collision.gameObject.tag != "Platform" && !justCollisionned && collision.gameObject.tag != "Bullet" )
		{
			KnockBack(1);

		}

		else if(collision.gameObject.tag == "KillZone"){
			Death();
		}
	}
	
	public void KnockBack(int damage)
	{
		justCollisionned = true;
		movementBlockTimer = .3f;
		airControl = false;
		grounded = false;
		anim.SetBool("Attack", false);
		if ( facingRight )
			rigidbody2D.velocity = new Vector2(-5, 9f);
		else
			rigidbody2D.velocity = new Vector2(5, 9f);
		gameObject.GetComponent<PlayerState>().TakeDamage(damage);

	}


	void Attack(int combo){
		float hitboxOffset;
		switch (combo){
		case 1:
			hitboxOffset = 0f;
			break;
		case 2:
			hitboxOffset = 0.5f;
			break;
		case 3:
			hitboxOffset = 1f;
			break;
		default :
			hitboxOffset = 0f;
			break;
		}

		isAttacking = true;
		if(facingRight){
			spawnPosAttack = new Vector3(transform.position.x+combo-hitboxOffset, transform.position.y, transform.position.z);
			spawnRotAttack = new Quaternion();
			spawnRotAttack.x = 50;
		}
		else{
			spawnPosAttack = new Vector3(transform.position.x-combo+hitboxOffset, transform.position.y, transform.position.z);
			spawnRotAttack = new Quaternion();
			spawnRotAttack.x = 50;
		}
		GameObject slash = GameObject.Instantiate(attack, spawnPosAttack, spawnRotAttack)as GameObject;
		Vector3 theScale = slash.transform.localScale;
		theScale.x *= combo;
		theScale.y *= combo;
		if(!facingRight){

			theScale.x *= -1;

		}
		slash.transform.localScale = theScale;
		slash.transform.parent = transform;
	}

	void Death(){
		isDying = true;
		deathDelay = 0.5f;
		
		//anim
	}

}
