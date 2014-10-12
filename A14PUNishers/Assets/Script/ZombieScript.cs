using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {
	private bool facingRight=true;
	public float moveSpeed=1;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition=transform.position;
		if(facingRight)
		{
			newPosition.x += moveSpeed * Time.deltaTime; 
		}
		else
		{
			newPosition.x -= moveSpeed * Time.deltaTime; 		
		}
		transform.position=newPosition;
	}
	public void Flip ()
	{
			facingRight = !facingRight;
			
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}
}
