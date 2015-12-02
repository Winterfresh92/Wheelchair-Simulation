using UnityEngine;
using System;
using System.Collections;

public class Participant {

	public GameObject gameObject;
	public DateTime finishTime;

	public int currentLap;

	public Participant(GameObject gameObject) {
		this.gameObject = gameObject;
		currentLap = 0;
	}
}
