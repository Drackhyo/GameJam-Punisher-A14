using UnityEngine;
using System.Collections;

public class AnimIntro : MonoBehaviour {

	int state;
	public GameObject bacorn;
	public GameObject rainbow;
	public GameObject bonhomme;
	public Sprite bonhomme2;
	public GUIText atext;
	string storyText = "The Gates of Hell have opened.\nYou are the Chosen One.\nArise and save humanity from its imminent doom. \n\n(Left click to continue)";
	int txtState = 0;

	public AudioClip holy;
	public AudioClip music;
	public AudioClip transformation;
	public AudioClip demonDeath;

	// Use this for initialization
	void Start () {
		state = 0;
		//bacorn = GameObject.FindGameObjectWithTag("bacorn");
		//rainbow = GameObject.FindGameObjectWithTag("rainbow");
		GetComponent<AudioSource>().PlayOneShot(music);
	}
	
	// Update is called once per frame
	void Update () {
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
			if(txtState < storyText.Length){
				atext.text += storyText[txtState];
				txtState++;
			}
			if(Input.GetKeyUp(KeyCode.Mouse0))
			{
				atext.text = "";
				state++;
				GetComponent<AudioSource>().PlayOneShot(holy);
			}
		}

		if(state == 2)
		{
			rainbow.transform.localScale = Vector3.Lerp(rainbow.transform.localScale, new Vector3(1f,30f,1f), 1.5f * Time.deltaTime);
			if(rainbow.transform.localScale.y >11)
			{
				bonhomme.GetComponent<SpriteRenderer>().sprite = bonhomme2;
			}
			if(rainbow.transform.localScale.y > 29.5f)
			{
				state++;
			}
		}

		if(state == 3)
		{
			Destroy(rainbow);
			state++;
			GetComponent<AudioSource>().PlayOneShot(transformation);
		}

		if (state == 4) 
		{
			bacorn.transform.position = Vector3.Lerp(bacorn.transform.position, new Vector3(13f,6f,0f), 3f * Time.deltaTime);
			if(bacorn.transform.position.x > 12.5f)
			{
				state++;
				GetComponent<AudioSource>().PlayOneShot(demonDeath);
			}
		}

		if (state == 5) 
		{
			bonhomme.GetComponent<Animator>().enabled = true;
			bonhomme.transform.position = Vector3.Lerp (bonhomme.transform.position, new Vector3(20f,bonhomme.transform.position.y,0f), 0.6f * Time.deltaTime);

			if(bonhomme.transform.position.x > 14.7f)
			{
				state++;
			}
		}
			
		if (state == 6) 
		{
			Application.LoadLevel("MainMenu");
		}
	}

}
