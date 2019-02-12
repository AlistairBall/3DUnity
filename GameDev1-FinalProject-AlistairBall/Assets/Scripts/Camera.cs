using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private float rotationSpeed;

    private Vector3 moveDirection = Vector3.zero;
    // Use this for initialization
    void Start () {

        rotationSpeed = 6;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape)) { Screen.lockCursor = false; }
        else
        {
            Screen.lockCursor = true;
            // mouse position on the x axis
            transform.Rotate(-Input.GetAxis("Mouse Y") * rotationSpeed, 0, 0);
        }
        
    }
}
