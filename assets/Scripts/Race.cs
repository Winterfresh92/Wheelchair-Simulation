using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Race : MonoBehaviour {

	public List<Participant> participants;
	protected DateTime startTime;
	protected List<DateTime> finishTimes;
	protected int winner;
	public bool raceOver;
	public bool pushedToDatabase;
	private PlayerContainer master;

	private static Race race;

	public static Race Instance () {
		if (!race) {
			race = FindObjectOfType (typeof(Race)) as Race;
		}

		return race;
	}

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Master").GetComponent<PlayerContainer> ();
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
		pushedToDatabase = false;
		startTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		if (raceOver && !pushedToDatabase) {
			Debug.Log (participants [winner].gameObject.name + " won!");
			TimeSpan raceTime = participants [winner].finishTime - startTime;
			int won = winner == 0 ? 1 : 0;
			DatabaseHandler.insertGame ("Race", (float)raceTime.TotalSeconds, 0, (float)raceTime.TotalSeconds, 0, 0, 0, 0, "Easy", won, DatabaseHandler.getPlayerId (master.Player.name, master.Player.birthday));
			pushedToDatabase = true;
		}
		if (!raceOver) {
			if (participants [0].finishTime != DateTime.MaxValue || participants [1].finishTime != DateTime.MaxValue) {
				if (participants [0].finishTime < participants [1].finishTime) {
					Debug.Log ("Player Wins!");
					winner = 0;
					raceOver = true;
				} else {
					Debug.Log ("Player Loses...");
					winner = 1;
					raceOver = true;
				}
			}
		}
	}
}
