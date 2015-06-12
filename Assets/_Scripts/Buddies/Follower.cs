using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour 
{
	public enum FollowerStates{											//STATES ENUM
		inactive,
		idle,															//..
		follow,															//..
		catchUp,
	};
	public FollowerStates _state;

	Transform player, myTransform;
	Rigidbody myRbody;
	NavMeshAgent myAgent;
	float distanceToPlayer;
	public float idleDist, followDist, catchUpDist, speed, rotationSpeed;

	void Start()
	{
		player = FindObjectOfType<PlayerMove>().transform;
		myTransform = GetComponent<Transform>();
		myRbody = GetComponent<Rigidbody>();
		myAgent = GetComponent<NavMeshAgent>();

		_state = FollowerStates.inactive;
	}

	void Update()
	{
		distanceToPlayer = Vector3.Distance(myTransform.position, player.position);			//CHECK DISTANCE TO PLAYER AND..

		if(_state == FollowerStates.inactive)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(distanceToPlayer <= idleDist)
				{
					_state = FollowerStates.idle;
				}
			}
		}else{

			if(Input.GetMouseButtonDown(0))
			{
				if(distanceToPlayer <= idleDist)
				{
					_state = FollowerStates.inactive;
					return;
				}
			}

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
		myAgent.speed = 0;
		myAgent.destination = player.position;
	}

	void FollowUpdate()
	{
//		Vector3 moveVector = player.transform.position - myTransform.position;
//		float randomRotation = Random.Range(100f,110f);
//		myRbody.AddForce(moveVector * (speed - 5) * Time.deltaTime);
//		myTransform.LookAt(player.position * rotationSpeed * Time.deltaTime);
//		myAgent.destination = player.position;
		myAgent.speed = 12;
		myAgent.destination = player.position;
	}

	void CatchupUpdate()
	{
//		Vector3 moveVector = player.transform.position - myTransform.position;
//		float randomRotation = Random.Range(100f,110f);
//		myRbody.AddForce(moveVector * speed * Time.deltaTime);
//		myTransform.LookAt(player.position * rotationSpeed * Time.deltaTime);
//		myAgent.destination = player.position;
		myAgent.speed = 15;
		myAgent.destination = player.position;
	}

//	FollowerStates ActivateFollower()
//	{
//
//	}
}