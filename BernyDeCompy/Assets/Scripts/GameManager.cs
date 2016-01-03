﻿using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{
	private string scoreTexte;

	static GameManager _instance;
	private int score;
	private bool alive;
	private bool dead;
	private int difficulty=1;
	// Use this for initialization

	public virtual void Awake(){
		DontDestroyOnLoad (this);
		if (_instance == null) {
			_instance = this;
		} else {
			Destroy (gameObject);
		}

	}

	void Start () {
		InitJEU ();
	}

	public void InitJEU(){
		score = 0;
		alive = true;
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			score++;
		}
	}

	public void revive (){
		score = 0;
		alive = true;
		//dead = false;
	}

	public void addScore(int toAdd){
		score += toAdd;
	}

	public int getScore(){
		return score;
	}

	public int getSpeed (){
		return difficulty;
	}

	public void die(){
		alive = false;
		Application.LoadLevel (2);
	}

	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (750, 0, 90, 50), "Score");
		scoreTexte = score.ToString();
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		GUI.Box (new Rect (760, 25, 70, 20), scoreTexte);
	}
}
