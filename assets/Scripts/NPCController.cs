using UnityEngine;
using System;
using System.Collections;

public class NPCController : MonoBehaviour {

	public GameObject gameObject;
	public Race race;
	
	// Use this for initialization
	void Start () {
		race = Race.Instance ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.name == "Cube") {
			race.participants[1].currentLap += 1;
			if (race.participants[1].currentLap > 1) {
				race.participants[1].finishTime = DateTime.Now;
			}
		}
	}
}
