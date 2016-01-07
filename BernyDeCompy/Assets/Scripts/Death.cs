using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Death : MonoBehaviour {
	GameManager GM;
	public Button but;
	void start(){
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void menu(){
		Application.LoadLevel (0);
	}
}