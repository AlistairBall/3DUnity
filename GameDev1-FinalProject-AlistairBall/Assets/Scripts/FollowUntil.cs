using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUntil : MonoBehaviour 
{
	//Var
	public bool active;
	public GameObject target;
	public float speed;
	public float veiwDistance;
	private RaycastHit cast;

	// Use this for initialization
	void Start () 
	{
		// Sets defaults for varribles
		if(target == null){target = GameObject.FindWithTag("Player");}
		if(speed == 0){speed = 0.1f;}
		if(veiwDistance == 0){veiwDistance = 10.0f;}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CheckTargetDistance())
		{
			active = true;

			if(AskPermission())
			{
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position , speed);
			}
		}
		else {active = false;}
	}

	bool CheckTargetDistance()
	{
		// Draw the same Raycast for Debuging [ **Not accurate to the other ray in game **]
		//Debug.DrawRay(transform.position, target.transform.position * veiwDistance, Color.cyan);

		// If target in range follow other wise, When target too far away stop following 
		if (Physics.Raycast(transform.position,( target.transform.position - transform.position) , out cast, veiwDistance) && cast.collider.tag.Equals("Player"))
		{
			//Debug.Log("Player Spotted");
			return true;
		}
		else {return false;}
	}

	bool AskPermission()
	{
		if ( this.GetComponent<Enemy>().currentAction == "FollowUntil")
        {
			return true;
            //Debug.Log( "Action Allowed" + this.name);
        }
		else
		{
			return false;
			//Debug.log("Action Overridden" + this.name);	
		}
	}
}
