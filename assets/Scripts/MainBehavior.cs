using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainBehavior : MonoBehaviour {

	private GameObject coin;
	private Vector3 tmp;
	private Collider[] result;
	private int collectCount;
	private int tries;
	private GameObject score;

	// Use this for initialization
	void Start () {
		coin = GameObject.Find ("Coin_1");
		collectCount = 0;
		tries = 0;
		score = GameObject.Find ("Score");
		do {
			tmp.Set (Random.Range (-115, 75),coin.transform.position.y,Random.Range (-100, 86));
			result = Physics.OverlapSphere (tmp, 2f);
			tries++;
		} while(result.Length != 0 && tries < 5);
		coin.transform.position = tmp;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, 20 * Time.deltaTime * 4, Space.World);
		if (collectCount == 3) {
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
			tmp.Set (Random.Range (-115, 75),coin.transform.position.y,Random.Range (-100, 86));
			result = Physics.OverlapSphere (tmp, 2f);
			tries++;
		} while(result.Length != 0 && tries < 5);
		coin.transform.position = tmp;

	}
}


