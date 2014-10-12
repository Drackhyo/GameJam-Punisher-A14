using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

	int health;

	float deathDelay = 0.6f;
	bool dead = false;

	public GameObject body;

	void Start()
	{
		if (rigidbody2D.gameObject.tag == "Human")
			health = 3;
		else
			health = 6;
	}

	void Update()
	{
		if(dead){
			deathDelay -= Time.deltaTime;

			if(deathDelay <= 0){
				Vector3 bodySpawnPos = new Vector3();
				bodySpawnPos.x = transform.position.x;
				bodySpawnPos.y = transform.position.y-.5f;
				bodySpawnPos.z = transform.position.z;

				Instantiate(body, bodySpawnPos, transform.rotation);
				Destroy(gameObject);
			}
		}

		else if (health <= 0)
			Dies();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
	}

	void Dies()
	{
		dead = true;

		if (rigidbody2D.gameObject.tag == "Human")
		{
			GetComponent<Animator>().SetBool("Dead", true);
		}

		else
		{
			Destroy(gameObject);
		}

	}
}
