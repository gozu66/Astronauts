using UnityEngine;
using System.Collections;

public class PlayerMove4 : MonoBehaviour 
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
		if(V != 0 && H == 0){
			myRbody.AddForce(camPivot.forward * (speed*Input.GetAxis("Vertical")));			//FWD + BCK PHYSICS FORCES + INPUT
		}else if(V == 0 && H != 0){
			myRbody.AddForce(camPivot.right * (speed*Input.GetAxis("Horizontal")));			//FWD + BCK PHYSICS FORCES + INPUT
		}else if(V != 0 && H != 0){
			myRbody.AddForce(camPivot.forward * ((speed/2)*Input.GetAxis("Vertical")));
			myRbody.AddForce(camPivot.right * ((speed/2)*Input.GetAxis("Horizontal")));
		}


		if(playerIsMoving)
		{
			Quaternion newFace = Quaternion.LookRotation(new Vector3(myRbody.velocity.x, 0, myRbody.velocity.z));
			playerMesh.rotation = Quaternion.Slerp(playerMesh.rotation, newFace, rotationSpeed);//(new Vector3(myRbody.velocity.x, 0, myRbody.velocity.z) * Time.deltaTime);
		}
	}
	
	void Update()
	{
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