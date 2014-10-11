using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

	int health;

	void Start()
	{
		if (rigidbody2D.gameObject.tag == "Human")
			health = 3;
		else
			health = 6;
	}

	void Update()
	{
		if (health <= 0)
			Dies();
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
	}

	void Dies()
	{
		if (rigidbody2D.gameObject.tag == "Human")
		{
			BecomeCorpse();
		}
		else
		{
			//demon death
		}
	}

	void BecomeCorpse()
	{

	}
}
