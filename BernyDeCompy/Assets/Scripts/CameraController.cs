using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public GameObject baseObject; // l’objet à suivre
	
	private Vector3 offset; // L’offset initial
	
	void Start ()
	{
		offset = transform.position - baseObject.transform.position;
	}
	
	void LateUpdate ()
	{
		transform.position = baseObject.transform.position + offset;
	}
}