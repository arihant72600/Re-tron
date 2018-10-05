using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletUpdate : MonoBehaviour {
	
	
//	public float speed = 10f;
	public float time = 0f;
	public float maxLife = 5f;
	public float bulletDamage = 50f;
	//public PlayerLook pl;
	// Use this for initialization
	void Start() {
		//pl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerLook>();
	}
	
	// Update is called once per frame
	void Update() {
//		transform.position += transform.forward * speed * Time.deltaTime;
		time += Time.deltaTime;
		if (time > maxLife) {
			Destroy(gameObject);
		}
	}
	
	public void OnCollisionEnter(Collision col) {
		//Debug.Log ("hit " + col.gameObject.tag);

		if (col.gameObject.tag.Equals("Enemy")) {
			Debug.Log ("was an enemy");
			EnemyHealth eh = col.gameObject.transform.root.GetComponent<EnemyHealth>();
			eh.takeDamage(bulletDamage);
			Destroy (gameObject);
			//MonkeyHealth mh = col.gameObject.GetComponent<MonkeyHealth>();
			//mh.damage(bulletDamage);
			//pl.numEnemies -= 1;
		}
		if (col.gameObject.tag == "player") {
			
		}
	}
}
