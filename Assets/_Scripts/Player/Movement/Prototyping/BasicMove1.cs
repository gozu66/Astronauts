using UnityEngine;
using System.Collections;

public class BasicMove1 : MonoBehaviour 
{
	public float speed, strafeSpeed, rotationSpeed;		//MOVEMENT SPEED	//ROTATION SPEED

	Rigidbody myRbody;			//RIGIDBODY COMPONENT
	Transform myTransform;		//TRANSFORM COMPONENT

	void Start () 
	{
		myRbody = GetComponent<Rigidbody>();			//CACHING RIGIDBODY COMPONENT
		myTransform = GetComponent<Transform>();		//CACHING TRANSFORM COMPONENT
	}
	
	void FixedUpdate () 
	{
		myRbody.AddForce(myTransform.forward 	* 	(speed			*	Input.GetAxis("Vertical")));		//FORWAR+BACK PHYSICS FORCES INPUT
		myRbody.AddForce(myTransform.right		*	(strafeSpeed	*	Input.GetAxis("Horizontal")));		//RIGHT + LEFT PHYSICS FORCES INPUT

		myRbody.AddTorque(myTransform.up		*	(rotationSpeed	*	Input.GetAxis("Mouse X")));			//ROTATIONAL PHYSICS FORCES INPUT
		myRbody.AddTorque(myTransform.up		*	(rotationSpeed	*	Input.GetAxis("Horizontal")));			//ROTATIONAL PHYSICS FORCES INPUT
	}
}
