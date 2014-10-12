using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float timeToExpire=7;
	private float timeElapsed=0;
	public int bulletType=1;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed+=Time.deltaTime;
		if(timeElapsed>timeToExpire)
		{
			Destroy (gameObject);
		}
	
	}
	void OnCollisionEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag=="Player")
		{
			coll.gameObject.GetComponent<PlatformerCharacter2D>().KnockBack(bulletType);
		}
		else if(bulletType>1)
		{
			if(coll.gameObject.tag=="Human")
			{
				coll.gameObject.GetComponent<AIController>().KnockBack(3);
			}
		}

		Destroy (gameObject);
	}
}
