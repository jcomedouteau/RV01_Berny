using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour{	
	//Musiques associées et volumes
	public AudioClip casse;
	private AudioSource source;
	private float volLowRange = 3f;
	private float volHighRange = 5.0f;
	float vol;

	//Le texte du score
	private string scoreTexte;
	//le score
	private int score;
	//la difficulté
	public float difficulty=2f;
	//Le singleton
	static GameManager _instance;
	//L'utilisateur est-il en vie?
	private bool alive;
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

	//Début de la partie, on initialise tout.
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

	//Quand on prend une mamie, on ajoute des points
	public void addScore(int toAdd){
		score += toAdd;
	}

	//retourne le score
	public int getScore(){
		return score;
	}

	public float getSpeed (){
		float ratio = difficulty + getScore()/1000f;
		return ratio;
	}

	//On atteind la fin du niveau
	public void endOfGame(){
		alive = false;
		Application.LoadLevel (2);
	}

	//Mort du personnage
	public void die(){
		source.PlayOneShot(casse, vol);
		alive = false;
		Application.LoadLevel (2);
	}
}
