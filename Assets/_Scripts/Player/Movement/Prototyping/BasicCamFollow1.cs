using UnityEngine;
using System.Collections;

public class BasicCamFollow1 : MonoBehaviour 
{
	public Transform lookPoint, movePoint;					//POINT TO LOOK TOWARDS		//POINT TO MOVE TOWARDS
	public float camMoveSpeed = 0.3f, Sensitivity = 1.0f;	//CAMERA MOVESPEED			//CAMERA LOOK SENSITIVITY

	Transform myTransform;	//CAMERA TRANSFORM
	Rigidbody camRbody;		//CAMERA RIGIDBODY

	void Start()
	{
		camRbody = GetComponent<Rigidbody>();				//CACHE CAMERA TRANSFORM
		myTransform = GetComponent<Transform>();			//CACHE CAMERA RIGIDBODY
	}

	void Update()
	{
		myTransform.LookAt(lookPoint.position, (Vector3.up));										//LOOK TOWARDS TARGET
		camRbody.MovePosition(Vector3.Lerp(transform.position, movePoint.position, camMoveSpeed));	//MOVE TOWARDS TARGET

		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			movePoint.localPosition += new Vector3(0f, 0f, Input.GetAxis("Mouse ScrollWheel"));
		}
	}
}