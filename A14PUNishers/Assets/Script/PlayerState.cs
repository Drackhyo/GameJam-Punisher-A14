using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	int health;
	int maxHealth = 6;
	int lives = 3;


	GameObject startLocation;

	void Start()
	{
		startLocation = GameObject.Find("LevelStart");
		ReplenishHealth();
		Respawn ();

	}
	void Update()
	{
		if (health <= 0)
			gameObject.GetComponent<PlatformerCharacter2D>().isDying = true;
	}

	public void TakeDamage(int amount)
	{
		health -= amount;
	}

	public void Dies()
	{
		lives--;
		if (lives > 0)
		{
			ReplenishHealth();
			Respawn();
		}
		else
		{
			Time.timeScale=0;
			GameObject.Find ("LevelStart").transform.GetComponentInChildren<EndGameGui>().enabled=true;
		}
	}

	public void ReplenishHealth()
	{
		health = maxHealth;
	}

	void Respawn()
	{
		transform.position = new Vector2(startLocation.transform.position.x, startLocation.transform.position.y);
	}

	public int getLives(){
		return lives;
	}
	public int getHealth(){
		return health;
	}
}
