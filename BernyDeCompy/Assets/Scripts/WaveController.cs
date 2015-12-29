using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	private int speed;
	public GameManager GM;

	// Use this for initialization
	void Start () {
		speed = GM.getSpeed ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0,0,speed*1.5f);
	}
}
