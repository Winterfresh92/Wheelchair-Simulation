using UnityEngine;
using System.Collections;

public class MainBehavior : MonoBehaviour {

	private GameObject coin;
	private Vector3 tmp;
	private Collider[] result;
	private int collectCount;
	private int tries;

	// Use this for initialization
	void Start () {
		coin = GameObject.Find ("Coin_1");
		collectCount = 0;
		tries = 0;
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
	}

	void OnCollisionEnter(Collision col) {
		tries = 0;
		do {
			tmp.Set (Random.Range (-115, 75),coin.transform.position.y,Random.Range (-100, 86));
			result = Physics.OverlapSphere (tmp, 2f);
			tries++;
		} while(result.Length != 0 && tries < 5);
		coin.transform.position = tmp;

	}
}


