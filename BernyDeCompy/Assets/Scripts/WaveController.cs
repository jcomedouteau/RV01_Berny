using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	private float speed;
	public GameManager GM;

	void Start () {
		}
	
	void Update () {
		speed = GM.getSpeed ();
		//Fais avancer la vague selon la vitesse définie
		transform.position += new Vector3 (0,0,speed*1.5f);
	}
}
