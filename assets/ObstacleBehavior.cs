using UnityEngine;
using System.Collections;

public class ObstacleBehavior : MonoBehaviour {

	GameObject obstacles;
	Vector3 temp;
	// Use this for initialization
	void Start () {
		obstacles = GameObject.Find ("Obstacles");

		Collider[] result;
		temp = new Vector3 ();
		int tries;
		foreach(Transform child in obstacles.transform)
		{
			tries = 0;
			do
			{
			  temp.x = Random.Range (-112, 85);
			  temp.y = child.position.y;
			  temp.z = Random.Range (-105, 93);
		      result = Physics.OverlapSphere(temp, 10f);
				tries++;
			} while(result.Length != 0 && tries < 5);

			child.position = temp;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
