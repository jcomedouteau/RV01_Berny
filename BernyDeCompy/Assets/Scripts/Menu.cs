using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (450, 150, 130, 90), "Berny de Compy");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (new Rect (460, 190, 110, 20), "Surfons la vague")) {
			Application.LoadLevel (1);
		}
	}
}
