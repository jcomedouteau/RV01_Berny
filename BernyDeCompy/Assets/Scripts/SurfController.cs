using UnityEngine;
using System.Collections;


public class SurfController : MonoBehaviour {
	//Vitesse de déplacement
	public float tSpeed = 1f;
	//Vitesse de rotation
	public float rSpeed = 10f;
	int result ;
	GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera");
	}



	// Update is called once per frame
	void Update () {
		//On fait avance le surf
		transform.position += new Vector3 (-transform.right.x*tSpeed, 0 , -transform.right.z*tSpeed);
		KeyboardMovements();
		//GameInstability ();
		CameraControl();

		//Are you dead?
		if (transform.rotation.eulerAngles.x > 20 && transform.rotation.eulerAngles.x < 340) {
			Application.LoadLevel(0);
		}
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

	//crée une instabilité aléatoire
	void GameInstability (){
		result = Random.Range (0, 10);
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
