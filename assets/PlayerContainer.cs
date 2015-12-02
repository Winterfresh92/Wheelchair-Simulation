using UnityEngine;
using System.Collections;

public class PlayerContainer : MonoBehaviour {
	public Player Player;

	public bool race;
	private AudioSource source;
	public AudioClip bgMusic;
	// Use this for initialization
	void Start () {
		Player = null;
		race = false;
		source = GetComponent<AudioSource> ();
		source.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
