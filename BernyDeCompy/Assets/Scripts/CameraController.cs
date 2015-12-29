using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	void LateUpdate ()
	{
		//Head on the left
		if(Input.GetKey("k"))
		{
			transform.Rotate(Vector3.forward);
		}

		//Head on the right
		if(Input.GetKey("m"))
		{
			transform.Rotate(-Vector3.forward);
		}

	}
}