using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public GameManager GM;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag != "grandmother") {
			GM.die ();
		} else {
			GM.addScore(1000);
		}
	}
	                    
}
