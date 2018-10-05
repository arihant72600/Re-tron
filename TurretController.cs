using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	public Rigidbody bullet;
	public float fireRate = 2f;
	public bool locked = false;
	float lockedTime = 0.0f;

	GameObject player;
//	GameObject weakBase;
	GameObject gunContainer;
	float bulletforce = 1000000f;

	// Use this for initialization
	void Start () {

		gunContainer = GameObject.Find("autoturret");
		player = GameObject.Find("player");
		//weakBase = GameObject.Find("Base");
	}

	// Update is called once per frame
	void Update () {
		if (locked) {
			gunContainer.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y - 2, player.transform.position.z));

			lockedTime += Time.deltaTime;

			if (lockedTime > fireRate) {
				lockedTime = 0;

				Vector3 v = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - 2 - transform.position.y, player.transform.position.z - transform.position.z);
				Rigidbody bulletInstance;
				bulletInstance = Instantiate(bullet, gunContainer.transform.position, gunContainer.transform.rotation) as Rigidbody;
				bulletInstance.AddForce(gunContainer.transform.forward * bulletforce);
			}
		}
	}

	void OnTriggerStay() {
		locked = true;
	}

	void OnTriggerExit() {
		locked = false;
	}
}
