using UnityEngine;
using System.Collections;

public class PlayerCamera4 : MonoBehaviour 
{
	public float speed;
	public Transform cameraTarget;

	Transform playerTarget, myTransform;
//
//	Camera _camera;
//
//	int xMin = 200, yMin = 50;
//	int xMax, yMax;
	Vector3 refV3 = Vector3.zero;
//	bool X, Y;
//	float DistX, DistY;

	void Start()
	{
		myTransform = GetComponent<Transform>();
//		_camera = GetComponent<Camera>();
//		playerTarget = FindObjectOfType<PlayerMove4>().transform;
//		xMax = _camera.pixelWidth - xMin;
//		yMax = _camera.pixelHeight - (yMin * 2);
	}

	void Update()
	{
//		Vector3 playerScreenPos = _camera.WorldToScreenPoint(playerTarget.position);
//
//		DistX = Mathf.Abs(playerTarget.position.x - myTransform.position.x);
//		DistY = Mathf.Abs(playerTarget.position.y - myTransform.position.y);
//		Debug.Log(DistX + "X  " + DistY + "Y");
//
//		if(playerScreenPos.x > xMax || playerScreenPos.x < xMin)
//		{
//			if(!X)
//				StartCoroutine("ScrollX");
//		}
//			
//		if(playerScreenPos.y > yMax || playerScreenPos.y < yMin)
//		{
//			if(!Y)
//				StartCoroutine("ScrollY");
//		}

		myTransform.position = Vector3.SmoothDamp(myTransform.position, cameraTarget.position, ref refV3, speed);
	}

//	IEnumerator ScrollX()
//	{
//		X = true;
//		yield return null;
//		X = false;
//	}
//
//	IEnumerator ScrollY()
//	{
//		Y = true;
//		yield return null;
//		Y = false;
//	}
}