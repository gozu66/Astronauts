using UnityEngine;
using System.Collections;

public class SpinOverTime : MonoBehaviour 
{
	public float spinSpeed;
	public bool doSpin;
	Transform myT;

	void Start()
	{
		myT = this.GetComponent<Transform>();
	}


	void Update()
	{
	if(doSpin)
		myT.Rotate(myT.up, spinSpeed * Time.deltaTime);
	}
}