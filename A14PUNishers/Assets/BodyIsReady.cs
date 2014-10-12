using UnityEngine;
using System.Collections;

public class BodyIsReady : MonoBehaviour {
	float fadeOut=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
		if (hit.collider != null)
		{
			if(hit.collider.gameObject.tag=="Player")
			{
				fadeOut=0.5f;
				transform.FindChild("Hover").GetComponent<SpriteRenderer>().enabled=true;
			}
		}
		fadeOut-=Time.deltaTime;
		if(fadeOut<=0)
			transform.FindChild("Hover").GetComponent<SpriteRenderer>().enabled=false;

	}

}
