using UnityEngine;
using System.Collections;

public class PlayerCamera3 : MonoBehaviour 
{
	public Transform lookPoint, movePoint, cameraPivot;			//POINT TO LOOK TOWARDS		//POINT TO MOVE TOWARDS
	public float camMoveSpeed = 0.3f, Sensitivity = 1.0f;		//CAMERA MOVESPEED			//CAMERA LOOK SENSITIVITY

	Transform myTransform;										//CAMERA TRANSFORM
	Rigidbody camRbody;											//CAMERA RIGIDBODY

	Vector3 refVelocity = Vector3.zero;
	float absDist, angVelMag;

	void Start()
	{
		camRbody = GetComponent<Rigidbody>();					//CACHE CAMERA TRANSFORM
		myTransform = GetComponent<Transform>();				//CACHE CAMERA RIGIDBODY
		myTransform.position = movePoint.position;				//MOVE CAMERA TO PLAYER ON START
	}

	void Update()
	{
		myTransform.LookAt(lookPoint.position, (Vector3.up));																	//LOOK TOWARDS TARGET
//		myTransform.RotateAround(cameraPivot.position, Vector3.up, (Sensitivity*Input.GetAxis("Mouse X")));						//ENABLE MOUSE ORBIT
//		cameraPivot.Rotate(Vector3.up, Sensitivity*Input.GetAxis("Mouse X"));
	}

	void FixedUpdate()											//FIXED UPDATE FOR PHYSICS
	{
		camRbody.MovePosition(Vector3.SmoothDamp(myTransform.position, movePoint.position, ref refVelocity, camMoveSpeed));		//MOVE CAMERA RIGIDBOSY
	}
}