using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Collections;
using System;

public class PlayerMagic : MonoBehaviour {
	public float speed = 3.0f;
	public float rotateSpeed = 25.0f;
	public float rotateSpeedGun = 0.5f;
	public float rotateTurret = 0.5f;
	public float rotationX = 0.0f;
	public float rotationY = 0.0f;

	public float bulletforce = 1000000f;

	GameObject gunContainer;
	GameObject gun;
	GameObject body;
	GameObject turret;

	SerialPort stream = new SerialPort ("COM3", 9600);


	string movementDirection="none";

	public Rigidbody bullet;
	// Use this for initialization
	void Start () {
		gunContainer = GameObject.Find("tankgun");
		gun = GameObject.Find("gunmesh");
		Renderer gunRenderer = gun.GetComponent<Renderer>();
		//gunRenderer.material.shader = Shader.Find("Specular");
		gunRenderer.material.SetColor("_SpecColor", Color.red);

		body = GameObject.Find("body");
		Renderer bodyRenderer = body.GetComponent<Renderer>();
		//bodyRenderer.material.shader = Shader.Find("Specular");
		bodyRenderer.material.SetColor("_SpecColor", Color.red);

		turret = GameObject.Find("turretmesh");
		Renderer turretRenderer = GetComponent<Renderer>();
		//turretRenderer.material.shader = Shader.Find("Specular");
		// turretRenderer.material.SetColor("_SpecColor", Color.red);

		stream.ReadTimeout = 500;
		stream.Open ();
	}

	// Update is called once per frame
	void Update () {
		double transAmount = speed * Time.deltaTime;
		double rotateAmount = rotateSpeed * Time.deltaTime;
		double factor = 1;
		string inputChange = "";
		try {
			inputChange = stream.ReadLine();
			Debug.Log(inputChange);
		} catch(TimeoutException e) {
			Debug.Log ("TimeOut");
		}

		if (inputChange.Equals ("Shoot")) {
			fireBullet();
		} else if (!(inputChange.Equals (""))) {
			movementDirection = inputChange;
		}

		if (movementDirection =="forward" || movementDirection=="forwardRight" || movementDirection=="forwardLeft") {
			transform.Translate(0, 0, (float) transAmount);

		}
		if (movementDirection=="back" || movementDirection=="backRight" || movementDirection=="backLeft") {
			transform.Translate(0, 0, (float) -transAmount);

		}
		if (movementDirection=="left" || movementDirection=="forwardLeft" || movementDirection=="backLeft") {
			transform.Rotate(0, (float) (-rotateAmount * factor), 0);
		}
		if (movementDirection=="right" || movementDirection=="forwardRight" || movementDirection=="backRight") {
			transform.Rotate(0, (float) (rotateAmount * factor), 0);
		}


		if (Input.GetKey("w")) {
			transform.Translate(0, 0, (float) transAmount);

		}
		if (Input.GetKey("s")) {
			transform.Translate(0, 0, (float) -transAmount);

		}
		if (Input.GetKey("a")) {
			transform.Rotate(0, (float) (-rotateAmount * factor), 0);
		}
		if (Input.GetKey("d")) {
			transform.Rotate(0, (float) (rotateAmount * factor), 0);
		}
		/*
		if (Input.GetKey("up")) {
			rotationX += rotateSpeedGun;
		}

		if (Input.GetKey("down")) {
			rotationX -= rotateSpeedGun;
		}

		if (Input.GetKey("left")) {
			rotationY -= rotateTurret;
		}

		if (Input.GetKey("right")) {
			rotationY += rotateTurret;
		}
*/


		if (Input.touchCount == 1 || Input.GetButtonDown ("Fire1")) {
			fireBullet();
		}


		//rotationX = Mathf.Clamp(rotationX, -10, 45);
		//3gunContainer.transform.localEulerAngles = new Vector3(-rotationX, 0, 0);
		 //turret.transform.localEulerAngles = new Vector3(0, rotationY, 0);

		//if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
		//nextFire = Time.time + fireInterval;
		//fire();
		//}
	}

	void fireBullet() {
		Rigidbody bulletInstance;
		bulletInstance = Instantiate(bullet, gunContainer.transform.position, gunContainer.transform.rotation) as Rigidbody;
		bulletInstance.AddForce (gunContainer.transform.forward * bulletforce);

	}
}
