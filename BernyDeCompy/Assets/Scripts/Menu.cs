using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	void OnGUI () {
		// Make a background box
		GUI.Box (new Rect (600, 100, 130, 90), "Berny de Compy");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if (GUI.Button (new Rect (610, 140, 110, 20), "Surfons la vague")) {
			Application.LoadLevel (1);
		}

		//Tuto
		GUI.Box (new Rect (750, 100, 400, 180), "Tutoriel : \n" +
			"Pour vous déplacer dans le jeu: \n" +
			"Le tapis de danse permet de tourner son surf. \n" +
			"L'oculus permet de rétablir l'équilibre sur le surf en penchant la tete. \n" +
			"Des déséquilibres aléatoires viendront vous désiquilibrer. \n" +
			"Plus vous avancez, plus vous gagnez des points. \n" +
			"Plus vous gagnez de points, plus vous acccélerez. \n" +
			"Attention, la vague vous suit, ne vous laissez pas rattraper. \n" +
			"Les mamies rapportent des points bonus ! \n" +
			"" +
			"Bon surf !");

	}
}
