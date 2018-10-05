using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//using UnityEngine.VR;

public class InputTrackerChecker : MonoBehaviour {
	private const string lofPrefix = "InputTrackerChecker: ";

	public float rotateSpeedY = 0.5f;
	public float rotateSpeedX = 0.5f;

	[SerializeField] UnityEngine.XR.XRNode m_VRNode = UnityEngine.XR.XRNode.Head;

	GameObject gun;
	GameObject player;

	// Use this for initialization
	void Start () {
		gun = GameObject.Find ("tankgun");
		player = GameObject.Find ("player");
	}

	// Update is called once per frame
	void Update () {
		Quaternion qua = InputTracking.GetLocalRotation(m_VRNode);
		Vector3 euler = qua.eulerAngles;

		float y = euler.y;
		float x = euler.x;

		// float t = transform.eulerAngles.y;
		float diffY = transform.eulerAngles.y - y;

		while (y < 0) {
			y += 360;
		}
		while (y > 360) {
			y -= 360;
		}
		/*
		while (x < 0) {
			x += 360;
		}
		while (x > 360) {
			x -= 360;
		}

*/
		/*
		if diffY > 180) {
			y += 360;
		}
		if (diffY < -180) {
			y -= 360;
		}
			
		Debug.Log("headset_y: " + y + "\ttank_y: " + transform.eulerAngles.y + "\tdiff: " + diffY);

		if (y < transform.eulerAngles.y) {
			// transform.Rotate(
			transform.localEulerAngles = new Vector3(0, rotateSpeedY, 0);
		}
		if (y > transform.eulerAngles.y) {
			transform.localEulerAngles = new Vector3(0, -rotateSpeedY, 0);
		}*/

		Debug.Log ("x: " + x);
		if (10 < x && x < 180) {
			x = 10;
		}
		if (180 < x && x < 330) {
			x = 330;
		}


		/*
		if (x < -45) {
			x = -45;
		}*/

		transform.eulerAngles = new Vector3(0, y + player.transform.eulerAngles.y, 0);
		gun.transform.eulerAngles = new Vector3(x, y + player.transform.eulerAngles.y, 0);
	}

}