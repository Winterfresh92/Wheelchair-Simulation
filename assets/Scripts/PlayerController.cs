using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		rigidBody = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float verticalInput = Input.GetAxis ("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");
		if (verticalInput < 0) {
			horizontalInput *= -1;
		}
		Vector3 vAcceleration = Vector3.forward * force * verticalInput;
		Vector3 hAcceleration = new Vector3(0, force *.50f * horizontalInput, 0);
		
		if ((verticalInput > 0 || verticalInput < 0)) {
			rigidBody.AddRelativeForce(vAcceleration, ForceMode.Acceleration);
			
		}
		if((horizontalInput > 0 || horizontalInput < 0)){
			rigidBody.AddTorque(hAcceleration, ForceMode.Acceleration);
		}
		
	}
	
	private GameObject player;
	private Rigidbody rigidBody;
	private float force = 6;
	private float turnForce;
	private Vector3 lastVelocity;
}