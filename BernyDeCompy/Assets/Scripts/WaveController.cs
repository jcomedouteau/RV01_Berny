using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	private int speed;
	public GameManager GM;

	void Start () {
		speed = GM.getSpeed ();
	}
	
	void Update () {
		//Fais avancer la vague selon la vitesse définie
		transform.position += new Vector3 (0,0,speed*1.5f);
	}
}
