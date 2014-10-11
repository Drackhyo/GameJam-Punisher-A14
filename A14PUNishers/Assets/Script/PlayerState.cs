using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	int health = 3;
	int lives = 3;

	bool hasHead = true;
	bool hasArms = true;
	bool hasLegs = true;

	GameObject startLocation;

	void Start()
	{
		startLocation = GameObject.Find("LevelStart");
		Respawn ();

	}
	void Update()
	{
		if (health <= 0)
			Dies();
	}

	void TakeDamage(int amount)
	{
		health -= amount;
	}

	public void Dies()
	{
		lives--;
		if (lives > 0)
		{
			Respawn();
		}
		else
		{
		    //gameover
		}
	}

	void Respawn()
	{
		transform.position = new Vector2(startLocation.transform.position.x, startLocation.transform.position.y);
	}
}
