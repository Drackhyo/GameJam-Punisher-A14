using UnityEngine;
using System.Collections;

public class BodyIsReady : MonoBehaviour {
	float fadeOut=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x-2f,transform.position.y+0.7f), Vector2.right,4);
		if (hit3.collider != null)
		{
			if(hit3.collider.gameObject.tag=="Player")
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
