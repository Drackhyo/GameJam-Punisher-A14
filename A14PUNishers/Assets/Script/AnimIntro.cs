﻿using UnityEngine;
using System.Collections;

public class AnimIntro : MonoBehaviour {

	int state;
	public GameObject bacorn;
	public GameObject rainbow;
	public GameObject bonhomme;
	public Sprite bonhomme2;


	// Use this for initialization
	void Start () {
		state = 0;
		//bacorn = GameObject.FindGameObjectWithTag("bacorn");
		//rainbow = GameObject.FindGameObjectWithTag("rainbow");
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
			//on met du texte
			if(Input.GetKeyUp(KeyCode.Space))
			{
				state++;
			}
		}

		if(state == 2)
		{
			rainbow.transform.localScale = Vector3.Lerp(rainbow.transform.localScale, new Vector3(1f,15f,1f), 1.5f * Time.deltaTime);
			if(rainbow.transform.localScale.y >11)
			{
				bonhomme.GetComponent<SpriteRenderer>().sprite = bonhomme2;
			}
			if(rainbow.transform.localScale.y > 14.5f)
			{
				state++;
			}
		}

		if(state == 3)
		{
			Destroy(rainbow);
			state++;
		}

		if (state == 4) 
		{
			bacorn.transform.position = Vector3.Lerp(bacorn.transform.position, new Vector3(13f,6f,0f), 3f * Time.deltaTime);
			if(bacorn.transform.position.x > 12.5f)
			{
				state++;
			}
		}
			
		if (state == 5) 
		{
			Application.LoadLevel("Stage1");
		}
	}

}