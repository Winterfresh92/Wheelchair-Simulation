using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuControlScript : MonoBehaviour
{

	private GameObject player;
	private GameObject titleMenu;
	private InputField inField;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		titleMenu = GameObject.Find ("TitleMenu");
		inField = titleMenu.GetComponentInChildren<InputField> ();

	
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	private bool checkInputBox ()
	{
		if (inField.text == "") {
			titleMenu.SetActive (true);
			inField.placeholder.GetComponent<Text> ().text = "You must enter your name!";
			return false;
		} else {
			if (Application.loadedLevelName != "TitleScreen") {
				pause ();
			}
			titleMenu.SetActive (false);
			return true;
		}
	}

	private void pause ()
	{
		player.GetComponent<PlayerController> ().pausePlayer ();
	}

	public void OnObstacleCourseClicked ()
	{
		if (checkInputBox ()) {
			if (Application.loadedLevelName != "FoodCourt") {
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
