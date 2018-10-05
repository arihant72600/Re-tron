using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float health = 120f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void takeDamage(float dam) {
		health -= dam;
	}
}
