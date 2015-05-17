using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour 
{
	public enum FollowerStates{											//STATES ENUM
		idle,															//..
		follow,															//..
		catchUp,
	};
	public FollowerStates _state;

	Transform player, myTransform;
	Rigidbody myRbody;
	float distanceToPlayer;
	public float idleDist, followDist, catchUpDist, speed, rotationSpeed;

	void Start()
	{
		player = FindObjectOfType<PlayerMove>().transform;
		myTransform = GetComponent<Transform>();
		myRbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		distanceToPlayer = Vector3.Distance(myTransform.position, player.position);			//CHECK DISTANCE TO PLAYER AND..
																							//..
		if(distanceToPlayer < idleDist)														//ASSIGN STATE ACCORDING TO DIST
		{																					//..
			_state = FollowerStates.idle;													//..
		}																					//..
		else if (distanceToPlayer > idleDist && distanceToPlayer < catchUpDist) 
		{
			_state = FollowerStates.follow;
		}
		else if (distanceToPlayer > catchUpDist) 
		{
			_state = FollowerStates.catchUp;
		}

		switch(_state)										//SWITCH STATEMENT 
		{													//FOR...SWITCHING
			case FollowerStates.idle:						//
				IdleUpdate();								//
			break;

			case FollowerStates.follow:
				FollowUpdate();
			break;

			case FollowerStates.catchUp:
				CatchupUpdate();
			break;
		}
	}

	void IdleUpdate()
	{

	}

	void FollowUpdate()
	{

	}

	void CatchupUpdate()
	{
		Vector3 moveVector = player.transform.position - myTransform.position;
		float randomRotation = Random.Range(100f,110f);
		myRbody.AddForce(moveVector * speed * Time.deltaTime);
		myTransform.LookAt(player.position * rotationSpeed * Time.deltaTime);
	}
}