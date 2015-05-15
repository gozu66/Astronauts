using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	public float speed, strafeSpeed, rotationSpeed;				//MOVEMENT SPEED	//ROTATION SPEED
	public float mouseSensitivity = 1.0f, jumpForce;
	float V, H;

	Rigidbody myRbody;											
	Transform myTransform, cameraTransf;						//CAMERA TRANSFORM  //TRANSFORM COMPONENT

	public static bool playerIsMoving;

	void Start () 
	{
		myRbody = GetComponent<Rigidbody>();					//CACHING RIGIDBODY
		myTransform = GetComponent<Transform>();				//CACHING TRANSFORM
		cameraTransf = Camera.main.GetComponent<Transform>();	//CACHING CAMERA TRANSFORM
	}
	
	void FixedUpdate () 
	{			
		myRbody.AddForce(myTransform.forward * (speed*Input.GetAxis("Vertical")));					//FORWAR+BACK PHYSICS FORCES INPUT

		transform.Rotate(0, Input.GetAxis("Horizontal")*rotationSpeed, 0);							//ROTATIONAL FORCES ON KEYS

		if(V != 0 && H == 0)
			transform.Rotate(0, (Input.GetAxisRaw("Mouse X")*rotationSpeed)*mouseSensitivity, 0);	//ROTATIONAL FORCES ON MOUSE (WHEN MOVING)

		if(Input.GetKeyDown(KeyCode.Space))
		{
			myRbody.velocity += new Vector3(0, jumpForce, 0);
			Debug.Log("SPACE");
		}
	}

	void Update()
	{
		V = Input.GetAxis("Vertical");
		H = Input.GetAxis("Horizontal");

		if(V != 0 || H != 0){
			playerIsMoving = true;
		}
		if(V == 0 && H == 0){
			playerIsMoving = false;		
		}
	}
}
