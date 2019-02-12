using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	// Currently doesnt do much but later will be the brain in every enemy that decideing
	// what action <-[Script] has most priority for the entity todo.

	// Var 
    public GameObject Player;
	public string currentAction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
		if ( this.GetComponent<FollowUntil>().active ){currentAction = "FollowUntil";}

		// By default just do normal patrol 
		else {currentAction = "TwoPointPatrol";}
		
		// Print Current action
	    //Debug.Log( "Current Action Is: " + currentAction);		
    }
}