using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	private float speed;
	GameManager GM;

	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		}
	
	void Update () {
		speed = GM.getSpeed ();
		//Fais avancer la vague selon la vitesse définie
		transform.position += new Vector3 (0,0,speed*0.75f);
	}
}
