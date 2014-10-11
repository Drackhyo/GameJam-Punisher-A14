using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

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
