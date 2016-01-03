using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	float lastEnteranceTime=-100f;
	public GameManager GM;
	public AudioClip mamieFarte;
	private AudioSource source;
	private float volLowRange = 3f;
	private float volHighRange = 5.0f;
	float vol;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		source = GetComponent<AudioSource> ();
		vol = Random.Range (volLowRange, volHighRange);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag != "grandmother") {			
			Debug.Log("coucou");
			GM.die ();
		} else {
			if(Time.time - lastEnteranceTime > 2)
			{
				source.PlayOneShot(mamieFarte,vol);
				GM.addScore(1000);
				lastEnteranceTime=Time.time;
			}

			//Destroy(other.gameObject);
		}
	}
	                    
}
