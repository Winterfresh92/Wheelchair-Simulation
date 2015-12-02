using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		pc = GameObject.Find ("Master").GetComponent ("PlayerContainer") as PlayerContainer;
		player = GameObject.Find("Player");
		rigidBody = player.GetComponent<Rigidbody>();
		titleMenu = GameObject.Find ("TitleMenu");
		arrow = GameObject.Find ("Arrow");
		if (Application.loadedLevelName != "TitleScreen") {
			titleMenu.SetActive(false);
			if(Application.loadedLevelName == "FoodCourt" && pc.race)
			{
				Vector3 temp = new Vector3(55.26f, player.transform.position.y, -7.3f);
				player.transform.position = temp;
				arrow.SetActive(false);
				GameObject.Find ("Coin_1").SetActive(false);
			}
		}
		paused = false;


		canvas = GameObject.Find ("Canvas");
		text = canvas.GetComponentInChildren<Text> ();
		race = Race.Instance ();
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
			

			if (Input.GetKey (KeyCode.Escape) && paused == false && !titleMenu.activeSelf) {
				titleMenu.SetActive(true);
				pausePlayer();
			}

		}
        if (arrow.activeSelf) {
			arrow.transform.LookAt (GameObject.Find ("Coin_1").transform);
		}
	}

	public void pausePlayer() {
		paused = !paused;
	}

	private PlayerContainer pc;
	private GameObject titleMenu;
	private bool paused;
	private GameObject player;
	private Vector3 tmp;

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Hit " + collider.gameObject.name);
		if (collider.gameObject.name == "Starting Line") {
			race.participants[0].currentLap += 1;
			Debug.Log (race.participants[0].currentLap);
			if(race.participants[0].currentLap > 1) {
				race.participants[0].finishTime = DateTime.Now;
			}
		}
	}

	public Text text;

	private GameObject canvas;
	private Participant participant;
	public Race race;
	private Rigidbody rigidBody;
	private float force = 6;
	private float turnForce;
	private Vector3 lastVelocity;
	private GameObject arrow;
}