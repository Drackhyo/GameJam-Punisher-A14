﻿using UnityEngine;
using System.Collections;

public class CommonActionMenu : MonoBehaviour {

	public Color enterColor = Color.green;
	public Color exitColor = Color.white;
	public int sizeIn = 60;
	public int sizeOut = 50;

	void OnMouseEnter(){
		guiText.material.color = enterColor;
		guiText.fontSize = sizeIn;
	}

	void OnMouseExit(){
		guiText.material.color = exitColor;
		guiText.fontSize = sizeOut;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
