using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	int health = 3;
	int lives = 3;

	bool hasHead = true;
	bool hasArms = true;
	bool hasLegs = true;

	void Update()
	{
		if (health <= 0)
			Dies();
	}

	void TakeDamage(int amount)
	{
		health -= amount;
	}

	void Dies()
	{
		if (lives > 0)
		{
			lives--;
			Respawn();
		}
		else
		{
		    //gameover
		}
	}

	void Respawn()
	{
		//Change position
		//Full health
	}
}
