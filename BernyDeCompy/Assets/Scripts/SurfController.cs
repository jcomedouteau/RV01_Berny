using UnityEngine;
using System.Collections;

public class SurfController : MonoBehaviour {
	public float tSpeed = 1f;
	public float rSpeed = 1f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//On fait avance le surf
		transform.position += new Vector3 (-transform.right.x, 0 , -transform.right.z);
		if (transform.rotation.eulerAngles.x > 20 && transform.rotation.eulerAngles.x < 340) {
			Debug.Log("vous etes MORT");
			Application.LoadLevel(1);
		}
		KeyboardMovements();
	}

	void KeyboardMovements()
	{

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(transform.forward, -rSpeed);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		   {
			transform.Rotate(transform.forward, rSpeed);
		}

		if(Input.GetKey("q")|| Input.GetKey (KeyCode.JoystickButton0)){
			transform.Rotate(transform.up, -rSpeed);
		}

		if(Input.GetKey("d") || Input.GetKeyDown (KeyCode.JoystickButton3))
		{
			transform.Rotate(transform.up, rSpeed);
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "endOfGame")
		{
			Application.LoadLevel(0);
		}

		if (col.gameObject.tag == "obstacle") {
			Debug.Log ("Vous etes MORT");
			//yield return new WaitForSeconds(2);
			Application.LoadLevel(1);
		}
	}

	// Pour la rotation aléatoire, utiliser Random.Range(-10.0F, 10.0F)
}
