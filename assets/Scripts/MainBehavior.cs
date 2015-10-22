using UnityEngine;
using System.Collections;

public class MainBehavior : MonoBehaviour {

	private GameObject coin;
	private Vector3 tmp;
	private Collider[] result;

	// Use this for initialization
	void Start () {
		coin = GameObject.Find ("Coin_1");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, 20 * Time.deltaTime * 4, Space.World);
	}

	void OnCollisionEnter(Collision col) {

		do {
			tmp.Set (Random.value * 10, coin.transform.position.y, Random.value * 10);
			result = Physics.OverlapSphere (tmp, 1f);
		} while(result.Length != 0);
		coin.transform.position = tmp;

	}
}


