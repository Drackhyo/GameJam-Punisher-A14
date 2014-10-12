using UnityEngine;
using System.Collections;

public class AnimIntro : MonoBehaviour {

	int state;
	GameObject bacorn;
	GameObject rainbow;

	// Use this for initialization
	void Start () {
		state = 0;
		bacorn = GameObject.FindGameObjectWithTag("bacorn");
		rainbow = GameObject.FindGameObjectWithTag("rainbow");
	}
	
	// Update is called once per frame
	void Update () {
		while(state < 4)
		{
			if(state == 0)
			{
				bacorn.transform.Translate(Vector2.MoveTowards(bacorn.transform.position, Vector2(-1f,3f), 5 * Time.deltaTime)); //bouger la bacorn

				if(bacorn.transform.position == Vector2(-1f,3f))
				{
					state++;
				}
			}

			/*if(state == 1)
			{
				//on met du texte
				if(Input.GetKeyUp(KeyCode.Space))
				{
					state++;
				}
			}

			if(state == 2)
			{
				rainbow.rigidbody2D.transform. //un scale
				if(/*rainbow a la bonne hauteur*)
				{
					state++;
				}
			}

			if(state == 3)
			{
				//Anim perso se lève
			}*/
		}
	}

}
