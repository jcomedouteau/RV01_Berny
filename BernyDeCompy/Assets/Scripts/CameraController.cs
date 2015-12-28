using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	void LateUpdate ()
	{
		//Head on the left
		if(Input.GetKey("k") || Input.GetKey (KeyCode.JoystickButton3))
		{
			transform.Rotate(Vector3.forward);
		}

		//Head on the right
		if(Input.GetKey("m") || Input.GetKey (KeyCode.JoystickButton3))
		{
			transform.Rotate(-Vector3.forward);
		}

	}
}