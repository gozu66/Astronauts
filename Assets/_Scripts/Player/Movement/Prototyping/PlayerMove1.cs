using UnityEngine;
using System.Collections;

public class PlayerMove1 : MonoBehaviour 
{
	public float speed, strafeSpeed, rotationSpeed;										//MOVEMENT SPEED	//ROTATION SPEED
	public float mouseSensitivity = 1.0f, jumpForce;
	float V, H;

	Rigidbody myRbody;											
	Transform myTransform;																//TRANSFORM COMPONENT

	public Transform camPivot, playerMesh;

	public static bool playerIsMoving;
	public static bool isGrounded;

	void Start () 
	{
		myRbody = GetComponent<Rigidbody>();											//CACHING RIGIDBODY
		myTransform = GetComponent<Transform>();										//CACHING TRANSFORM
	}

	void FixedUpdate () 																//FIXED UPDATE FOR PHYSICS
	{	
		myRbody.AddForce(camPivot.forward * (speed*Input.GetAxis("Vertical")));			//FWD + BCK PHYSICS FORCES + INPUT
	}

	void Update()
	{
		if(Input.GetAxis("Vertical") >= 0)
			myTransform.Rotate(transform.up, rotationSpeed * (Time.deltaTime*Input.GetAxis("Horizontal")));

		V = Input.GetAxis("Vertical");													//CACHING AXES
		H = Input.GetAxis("Horizontal");												//...

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded)								//.. 
		{
			myRbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);		
		} 

		if(V != 0 || H != 0){
			playerIsMoving = true;														//SETTING STAIC BOOL "PLAYERISMOVING"
		}																				//ON INPUT
		if(V == 0 && H == 0){															//..
			playerIsMoving = false;														//..
		}																				//..

		RaycastHit hit;
		if(Physics.Raycast(transform.position, -Vector3.up, out hit, 1.5f))				//..
		{																				//RAYCASH FOR GROUNDCHECK
			isGrounded = true;															//GROUNDED BOOLEAN
		} else {																		//..
			isGrounded = false;															//..
		}																				//..
	}

	public void SpeedEdit(float newSpeed)
	{
		speed = newSpeed;
	}

	public void RSpeedEdit(float newRSpeed)
	{
		rotationSpeed = newRSpeed;
	}
}