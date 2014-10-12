using UnityEngine;
using System.Collections;

public class AnimIntro : MonoBehaviour {

	int state;
	public GameObject bacorn;
	public GameObject rainbow;


	// Use this for initialization
	void Start () {
		state = 0;
		//bacorn = GameObject.FindGameObjectWithTag("bacorn");
		//rainbow = GameObject.FindGameObjectWithTag("rainbow");
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 pos = new Vector3(-1f,3f,0f);
		//while(state < 4)
		//{
			if(state == 0)
			{
			bacorn.transform.position = Vector3.Lerp(bacorn.transform.position, new Vector3(-1f,3f,0f), 3f * Time.deltaTime); //bouger la bacorn

			if(bacorn.transform.position.x <= -0.99f && bacorn.transform.position.x >= -1.01f)
				{
					state++;
				}
			}

			if(state == 1)
			{
				//on met du texte
				if(Input.GetKeyUp(KeyCode.Space))
				{
					state++;
				}
			}

			/*if(state == 2)
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
	//}

}
