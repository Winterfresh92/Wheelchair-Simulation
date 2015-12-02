using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class MainBehavior : MonoBehaviour {

	private GameObject coin;
	private Vector3 tmp;
	private Collider[] result;
	private int collectCount;
	private int tries;
	private GameObject score;
	private DateTime startTime;
	private PlayerContainer master;
	private bool pushedToDatabase;

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Master").GetComponent<PlayerContainer>();
		coin = GameObject.Find ("Coin_1");
		collectCount = 0;
		tries = 0;
		score = GameObject.Find ("Score");
		do {
			tmp.Set (UnityEngine.Random.Range (-115, 75),coin.transform.position.y,UnityEngine.Random.Range (-100, 86));
			result = Physics.OverlapSphere (tmp, 2f);
			tries++;
		} while(result.Length != 0 && tries < 5);
		coin.transform.position = tmp;
		startTime = DateTime.Now;
		pushedToDatabase = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, 20 * Time.deltaTime * 4, Space.World);
		if (collectCount == 3) {
			TimeSpan playTime = DateTime.Now - startTime;
			if (!pushedToDatabase) {
				DatabaseHandler.insertGame("Collection", (float)playTime.TotalSeconds, 0, 0, 0, 0, 3, 0, "Hard", 1, DatabaseHandler.getPlayerId(master.Player.name, master.Player.birthday));
				pushedToDatabase = true;
			}
			GameObject.Find ("Notification").GetComponent<Text>().text = "You won!";
		}
	}

	void OnCollisionEnter(Collision col) {
		tries = 0;
		if (col.gameObject.name == "Player") {
			collectCount++;
			score.GetComponent<Text>().text = collectCount.ToString();
		}
		do {
			tmp.Set (UnityEngine.Random.Range (-115, 75),coin.transform.position.y,UnityEngine.Random.Range (-100, 86));
			result = Physics.OverlapSphere (tmp, 2f);
			tries++;
		} while(result.Length != 0 && tries < 5);
		coin.transform.position = tmp;

	}
}


