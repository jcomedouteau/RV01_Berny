using UnityEngine;
using System.Collections;


public class SurfController : MonoBehaviour {
	public float tSpeed = 10f;
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
		if (transform.rotation.eulerAngles.x > 20 && transform.rotation.eulerAngles.x < 340) {
			Debug.Log("vous etes MORT");
			Application.LoadLevel(1);
		}
		KeyboardMovements();
		//GameInstability ();
		CameraControl();
	}

	void KeyboardMovements()
	{

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate (new Vector3(-rSpeed,0,0));
		}
		if(Input.GetKey(KeyCode.RightArrow))
		   {
			transform.Rotate (new Vector3(rSpeed,0,0));
		}

		if(Input.GetKey("q")|| Input.GetKey (KeyCode.JoystickButton0)){
			transform.Rotate(transform.up, -rSpeed);
		}

		if(Input.GetKey("d") || Input.GetKey (KeyCode.JoystickButton3))
		{
			transform.Rotate(transform.up, rSpeed);
		}
	}

	void CameraControl ()
	{
		throw new System.NotImplementedException ();
	}

	int GetRotationZone (){
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
				transform.Rotate (transform.forward, rSpeed);

			}
			else if (transform.rotation.eulerAngles.x > 180) {
				transform.Rotate (transform.forward, -rSpeed);

			}
			else{
				if (Random.Range(0,1)==0)
					transform.Rotate (transform.forward, -rSpeed);
				else
					transform.Rotate (transform.forward, rSpeed);

			}			//transform.Rotate (transform.forward, 5);
		}


	}

	// Pour la rotation aléatoire, utiliser Random.Range(-10.0F, 10.0F)
}
