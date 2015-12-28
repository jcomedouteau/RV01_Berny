using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int score;
	private bool alive;
	private bool dead;
	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (this);
	}

	void Start () {
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

	public void addScore(int toAdd){
		score += toAdd;
	}

	public int getScore(){
		return score;
	}

	public void die(){
		alive = false;
		Application.LoadLevel (2);
	}
}
