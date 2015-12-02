using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MenuControlScript : MonoBehaviour
{

	private GameObject player;
	private GameObject titleMenu;
	private InputField inField;
	private PlayerContainer master;
	// Use this for initialization
	void Start ()
	{
		master = GameObject.Find ("Master").GetComponent("PlayerContainer") as PlayerContainer;
		player = GameObject.Find ("Player");
		titleMenu = GameObject.Find ("TitleMenu");
		inField = titleMenu.GetComponentInChildren<InputField> ();
		if (master.Player != null) {
			inField.text = master.Player.name;
		}
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	private bool checkInputBox ()
	{
		if (inField.text == "") {
			titleMenu.SetActive(true);
			inField.placeholder.GetComponent<Text> ().text = "You must enter your name!";
			return false;
		} else {
			if (Application.loadedLevelName != "TitleScreen") {
				pause ();
			}
			master.Player = new Player();
			master.Player.birthday = DateTime.Today;
			master.Player.name = inField.text;
			DatabaseHandler.insertPlayer(master.Player.name, master.Player.birthday);
			titleMenu.SetActive(false);
			return true;
		}
	}

	private void pause ()
	{
		player.GetComponent<PlayerController> ().pausePlayer ();
	}

	public void OnRaceClicked()
	{
		if (checkInputBox ()) {
			if (Application.loadedLevelName != "FoodCourt") {
				master.race = true;
				Application.LoadLevel ("FoodCourt");
			}
		}
	}

	public void OnObstacleCourseClicked ()
	{
		if (checkInputBox ()) {
			if (Application.loadedLevelName != "FoodCourt") {
				master.race = false;
				Application.LoadLevel ("FoodCourt");
			}
		}
	}

	public void OnPracticeClicked ()
	{
		if (checkInputBox ()) {
			if (Application.loadedLevelName != "Room") {
				Application.LoadLevel ("Room");
			}
		}
	}


	public void exit ()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
}
