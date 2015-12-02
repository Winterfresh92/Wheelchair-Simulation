using UnityEngine;
using System.Collections;

public class MoveToCoin : MonoBehaviour {

	private NavMeshAgent agent;
	public GameObject coin;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (coin.transform.position);
	}
}
