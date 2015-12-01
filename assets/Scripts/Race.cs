using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Race {

	protected List<Participant> participants { get; private set; }

	// Use this for initialization
	void Start () {
		this.participants = new List<Participant> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
