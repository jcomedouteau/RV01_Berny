using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerEnd : MonoBehaviour {
	private GameManager GM;
	public Text tex;
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		tex.text = "Tu as perdu avec un score de : " + GM.getScore ();
	}
}
