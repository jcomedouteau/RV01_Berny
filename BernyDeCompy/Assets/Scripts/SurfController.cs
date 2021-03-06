﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SurfController : MonoBehaviour {
	//Vitesse de rotation
	public float rSpeed ;
	//Images gauches et droite
	public Image left;
	public Image right;
	int result ;
	GameObject cam;
	GameManager GM;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GameManager").GetComponent<GameManager>();
		cam = GameObject.Find ("Main Camera");
		rSpeed = 1;
	}

	// Update is called once per frame
	void Update () {
		//On fait avance le surf
		transform.position += (Vector3.Normalize(new Vector3 (-transform.right.x, 0 , -transform.right.z)))*GM.getSpeed();
		KeyboardMovements();
		//GameInstability ();
		CameraControl();
		OrientationInformation ();
		//Are you dead?
		if (transform.rotation.eulerAngles.x > 20 && transform.rotation.eulerAngles.x < 340) {
			GM.die();
		}
		//Pour quand on joue "a la main"
		KeyboardMovements();
		//Rotations aléatoires
		GameInstability ();

	}

	void KeyboardMovements()
	{
		//Rotation de la planche, equilibre -> Réalisé avec la caméra dans le jeu
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate (new Vector3(-rSpeed,0,0));
		}
		if(Input.GetKey(KeyCode.RightArrow))
		   {
			transform.Rotate (new Vector3(rSpeed,0,0));
		}

		//Rotation de la planche vers la gauche et la droite (direction)
		if(Input.GetKey("q")|| Input.GetKey (KeyCode.JoystickButton0)){
			transform.Rotate(new Vector3(0,1,0), -rSpeed);
		}

		if(Input.GetKey("d") || Input.GetKey (KeyCode.JoystickButton3))
		{
			transform.Rotate(new Vector3(0,1,0), rSpeed);
		}
	}

	void CameraControl ()
	{
		//La rotation de la main camera (oculus) permet de controler la stabilité de la planche.
		transform.Rotate(new Vector3(GetRotationZone()/10,0,0));
	}

	//Retourne le degré de rotation de la caméra par rapport à la planche.
	float GetRotationZone (){
		int val = 0;
		if (cam.transform.localEulerAngles.z > 5 && cam.transform.localEulerAngles.z < 15)
			val = -1;
		if (cam.transform.localEulerAngles.z >= 15 && cam.transform.localEulerAngles.z < 30)
			val = -2;
		if (cam.transform.localEulerAngles.z >= 30 && cam.transform.localEulerAngles.z < 45)
			val = -3;
		if (cam.transform.localEulerAngles.z >= 45 && cam.transform.localEulerAngles.z < 90)
			val = -4;
		if (cam.transform.localEulerAngles.z > 340 && cam.transform.localEulerAngles.z < 355)
			val = 1;
		if (cam.transform.localEulerAngles.z >= 325 && cam.transform.localEulerAngles.z < 340)
			val = 2;
		if (cam.transform.localEulerAngles.z >= 310 && cam.transform.localEulerAngles.z < 325)
			val = 3;
		if (cam.transform.localEulerAngles.z >= 270 && cam.transform.localEulerAngles.z < 310)
			val = 4;
		return val;	
	}

	//affiche les images selon la rotation de la planche
	void OrientationInformation(){
		if (transform.rotation.eulerAngles.x > 0 && transform.rotation.eulerAngles.x < 180) {
			left.enabled = true;
			right.enabled = false;
		} else if (transform.rotation.eulerAngles.x > 180) {
			left.enabled = false;
			right.enabled = true;		
		} else {
			left.enabled = false;
			right.enabled = false;		
		}
	}

	//crée une instabilité aléatoire
	void GameInstability (){
		result = Random.Range (0, 25);
		if (result == 0) {
			if (transform.rotation.eulerAngles.x > 0 && transform.rotation.eulerAngles.x < 180) {
				transform.Rotate (new Vector3(rSpeed,0,0));
			}
			else if (transform.rotation.eulerAngles.x > 180) {
				transform.Rotate (new Vector3(-rSpeed,0,0));

			}
			else{
				if (Random.Range(0,1)==0)
					transform.Rotate (new Vector3(-rSpeed,0,0));
				else
					transform.Rotate (new Vector3(rSpeed,0,0));
			}
		}
	}
}
