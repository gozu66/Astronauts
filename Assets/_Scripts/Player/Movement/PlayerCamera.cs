using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour 
{
	public float speed;
	public Transform cameraTarget;

	Transform playerTarget, myTransform;
	Vector3 refV3 = Vector3.zero;

	void Start()
	{
		myTransform = GetComponent<Transform>();
	}

	void Update()
	{
		myTransform.position = Vector3.SmoothDamp(myTransform.position, cameraTarget.position, ref refV3, speed);
	}
}