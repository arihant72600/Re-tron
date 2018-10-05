using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void takeDamage(float dam) {

		health -= dam;
		Debug.Log("health:" + health);

	}

	void LateUpdate() {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
