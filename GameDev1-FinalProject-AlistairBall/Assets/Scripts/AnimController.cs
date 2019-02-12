using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {


    Animator anim;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("Shooting 1 hand");
            anim.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Shooting 2 hands");
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Spell");
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Dead");
            anim.SetBool("IsRunning", false);
        }


    }
}
