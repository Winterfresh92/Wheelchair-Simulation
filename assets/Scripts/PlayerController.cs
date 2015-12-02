using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		canvas = GameObject.Find ("Canvas");
		rigidBody = player.GetComponent<Rigidbody>();
		text = canvas.GetComponentInChildren<Text> ();
		race = Race.Instance ();
		setLapText ();
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
		race.Update();
	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Hit " + collider.gameObject.name);
		if (collider.gameObject.name == "Cube") {
			race.participants[0].currentLap += 1;
			setLapText();
			if(race.participants[0].currentLap > 1) {
				race.participants[0].finishTime = DateTime.Now;
				text.text = "You've completed the race!";
			}
		}
	}

	void setLapText() {
		text.text = "Lap: " + race.participants[0].currentLap.ToString ();
	}

	public Text text;

	private GameObject player;
	private GameObject canvas;
	private Participant participant;
	public Race race;
	private Rigidbody rigidBody;
	private float force = 6;
	private float turnForce;
	private Vector3 lastVelocity;
}