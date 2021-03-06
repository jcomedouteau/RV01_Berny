﻿using UnityEngine;
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

	void OnCollisionEnter(Collision col) {
		GM.die ();
	}

	void OnTriggerEnter(Collider other) {
		//Si on rencontre une grand mere on augmente les points, sinon on meurt.
		if (other.gameObject.tag == "grandmother") {		
			if (Time.time - lastEnteranceTime > 2) {
				source.PlayOneShot (mamieFarte, vol);
				GM.addScore (1000);
				lastEnteranceTime = Time.time;
			}
		} else if (other.gameObject.tag == "endOfGame") {
			GM.endOfGame();
		} else {
			GM.die ();
		}
	}
	                    
}
