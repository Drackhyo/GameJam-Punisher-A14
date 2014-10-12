using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

	int health;

	float deathDelay = 0.4f;
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
				Instantiate(body, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}

		else if (health <= 0)
			Dies();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
		Debug.Log(health);
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
