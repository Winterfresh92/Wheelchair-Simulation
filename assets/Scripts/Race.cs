using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Race : MonoBehaviour {

	public List<Participant> participants;
	protected DateTime startTime;
	protected List<DateTime> finishTimes;
	protected int winner;
	protected bool raceOver;

	private static Race race;

	public static Race Instance () {
		if (!race) {
			race = FindObjectOfType (typeof(Race)) as Race;
		}

		return race;
	}

	// Use this for initialization
	void Start () {
		this.participants = new List<Participant> ();
		participants.Add(new Participant(GameObject.Find("Player")));

		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Participant");
		for (int j = 0; j < gameObjects.Length; j++) {
			Participant temp = new Participant(gameObjects[j]);
			participants.Add(temp);
		}
		for (int i = 0; i < participants.Count; i++) {
			Debug.Log(participants[i].gameObject.tag.ToString());
		}
		winner = 0;
		raceOver = false;
		startTime = DateTime.Now;
	}
	
	// Update is called once per frame
	public void Update () {
		if (raceOver) {
			Debug.Log(participants[winner].gameObject.name + " won!");
		}
		if (participants [0].finishTime != DateTime.MinValue || participants[1].finishTime != DateTime.MinValue) {
			if (participants [0].finishTime > participants [1].finishTime) {
				Debug.Log ("Player Wins!");
			} else {
				Debug.Log ("Player Loses...");
			}
		}
	}
}
