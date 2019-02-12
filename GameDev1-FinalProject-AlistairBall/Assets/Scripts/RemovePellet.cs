using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;

public class RemovePellet : MonoBehaviour {


    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter()
    {
        Destroy(gameObject, 6);
    }
}
