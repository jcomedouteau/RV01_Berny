using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	private int score = 0;
	public GameManager GM;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		score = GM.getScore();
		gameObject.GetComponent<Text>().text = "Score : "+ score;
	}


}


