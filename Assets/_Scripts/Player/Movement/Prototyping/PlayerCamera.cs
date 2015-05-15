using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour 
{
	public Transform lookPoint, movePoint, cameraPivot;			//POINT TO LOOK TOWARDS		//POINT TO MOVE TOWARDS
	public float camMoveSpeed = 0.3f, Sensitivity = 1.0f;		//CAMERA MOVESPEED			//CAMERA LOOK SENSITIVITY

	Transform myTransform;	//CAMERA TRANSFORM
	Rigidbody camRbody;		//CAMERA RIGIDBODY

	void Start()
	{
		camRbody = GetComponent<Rigidbody>();					//CACHE CAMERA TRANSFORM
		myTransform = GetComponent<Transform>();				//CACHE CAMERA RIGIDBODY
		myTransform.position = movePoint.position;				//MOVE CAMERA TO PLAYER ON START
	}

	void Update()
	{
		myTransform.LookAt(lookPoint.position, (Vector3.up));																//LOOK TOWARDS TARGET

		if(!PlayerMove.playerIsMoving && camRbody.velocity.magnitude <= 1)													//IF PLAYER+CAM HAVE STOPPED MOVING
		{
			myTransform.RotateAround(cameraPivot.position, Vector3.up, (Sensitivity*Input.GetAxis("Mouse X")));				//ENABLE MOUSE ORBIT
		}else {
			camRbody.MovePosition(Vector3.Lerp(transform.position, movePoint.position, (camMoveSpeed*Time.deltaTime)));		//ELSE LERP CAMERA TO MOVEPOINT
		}

	}
}