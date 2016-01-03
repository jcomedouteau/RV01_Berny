using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	float lastEnteranceTime=-100f;
	public GameManager GM;
	public AudioClip mamieFarte;
	private AudioSource source;
	private float volLowRange = 3f;
	private float volHighRange = 5.0f;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag != "grandmother") {
			GM.die ();
		} else {
			if(Time.time - lastEnteranceTime > 2)
			{
				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot(mamieFarte,vol);
				GM.addScore(1000);
				lastEnteranceTime=Time.time;
			}

			//Destroy(other.gameObject);
		}
	}
	                    
}
