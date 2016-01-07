using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnCreation : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		//Quand on revient au menu, on fait en sorte que le bouton charge bien le début du jeu
		GameObject.Find("Tuto").GetComponentInChildren<Button>().onClick.AddListener(() => {
			GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
			});
		//pareil pour le slider
		GameObject.Find("Tuto").GetComponentInChildren<Slider>().onValueChanged.AddListener((float val) => {
			GameObject.Find("GameManager").GetComponent<GameManager>().difficulty = val;
		});
	}
	
	// Update is called once per frame
	void Update () {

	}
}
