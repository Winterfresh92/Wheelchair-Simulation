using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		rigidBody = player.GetComponent<Rigidbody>();
		titleMenu = GameObject.Find ("TitleMenu");
		if (Application.loadedLevelName != "TitleScreen") {
			titleMenu.SetActive(false);
		}
		paused = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!paused) {
			float verticalInput = Input.GetAxis ("Vertical");
			float horizontalInput = Input.GetAxis ("Horizontal");
			if (verticalInput < 0) {
				horizontalInput *= -1;
			}


			Vector3 vAcceleration = Vector3.forward * force * verticalInput;
			Vector3 hAcceleration = new Vector3 (0, force * .50f * horizontalInput, 0);
		
			if ((verticalInput > 0 || verticalInput < 0)) {
				rigidBody.AddRelativeForce (vAcceleration, ForceMode.Acceleration);
			
			}
			if ((horizontalInput > 0 || horizontalInput < 0)) {
				rigidBody.AddTorque (hAcceleration, ForceMode.Acceleration);
			}
		}

		if (Input.GetKey (KeyCode.Escape) && paused == false && !titleMenu.activeSelf) {
			titleMenu.SetActive(true);
			pausePlayer();
		}

	}

	public void pausePlayer() {
		paused = !paused;
	}
	
	private GameObject titleMenu;
	private bool paused;
	private GameObject player;
	private Vector3 tmp;
	private Rigidbody rigidBody;
	private float force = 6;
	private float turnForce;
	private Vector3 lastVelocity;
}