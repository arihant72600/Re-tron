﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {
	public GameObject cv;

	bool won = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter() {
		cv.SetActive (true);
	}
}
