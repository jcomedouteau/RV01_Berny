using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{	public AudioClip casse;
	private AudioSource source;
	private float volLowRange = 3f;
	private float volHighRange = 5.0f;
	float vol;
	private string scoreTexte;

	static GameManager _instance;
	private int score;
	private bool alive;
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
		alive = false;
	}

	public void StartGame(){
		Application.LoadLevel (1);
		score = 0;
		alive = true;
		source = GetComponent<AudioSource> ();
		vol = Random.Range (volLowRange, volHighRange);
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

	public float getSpeed (){
		float ratio = 1.0f + getScore()/1000;
		return ratio;
	}

	public void endOfGame(){
		alive = false;
		Application.LoadLevel (2);
	}

	public void die(){
		source.PlayOneShot(casse, vol);
		alive = false;
		Application.LoadLevel (2);
	}
}
