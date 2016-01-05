using UnityEngine;
using System.Collections;

public class EndOfGame : MonoBehaviour {
	GameManager GM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		// Make a background box
		GUI.Box (new Rect (600, 100, 200, 100), "Bravo, vous avez gagné ! \n Votre score : "+GM.getScore().ToString());		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (new Rect (610, 170, 180, 20), "Recommencer")) {
			GM.InitJEU ();
			Application.LoadLevel (1);
		}
		// Make the second button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (new Rect (610, 140, 180, 20), "Retour au menu")) {
			//GM.revive ();
			Application.LoadLevel (0);
		}
	}
}
