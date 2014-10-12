using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

	int health;

	float deathDelay = 0.6f;
	bool dead = false;

	public AudioClip humanDeath;
	public AudioClip hit;

	public GameObject body;

	void Start()
	{
		if (rigidbody2D.gameObject.tag == "Human")
			health = 2;
		else
			health = 4;
	}

	void Update()
	{
		if(dead){
			GetComponent<Animator>().SetBool("IsStunned", true);
			deathDelay -= Time.deltaTime;

			if (rigidbody2D.gameObject.tag == "Demon")//shrink
			{
				transform.localScale=transform.localScale*0.9f;
			}
			if(deathDelay <= 0){
				if (rigidbody2D.gameObject.tag == "Human")
				{
					Vector3 bodySpawnPos = new Vector3();
					bodySpawnPos.x = transform.position.x;
					bodySpawnPos.y = transform.position.y-.5f;
					bodySpawnPos.z = transform.position.z;

					Instantiate(body, bodySpawnPos, transform.rotation);
				}

				Destroy(gameObject);
			}
			else if (deathDelay <= 0.5f)
			{
				GetComponent<Animator>().SetBool("Dead", true);
			}
		}

		else if (health <= 0)
			Dies();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		gameObject.GetComponent<AudioSource>().PlayOneShot(hit);
	}

	void Dies()
	{
		dead = true;
		gameObject.GetComponent<AudioSource>().PlayOneShot(humanDeath);
	}
}
