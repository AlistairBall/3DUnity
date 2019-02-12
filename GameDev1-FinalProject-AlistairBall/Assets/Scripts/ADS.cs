// BasicFPSController
// Ryan H. Berriualt
// On right click aim down sights

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour 
{
	public GameObject fpsCam;
	public float zoom;
	private Camera cam;
	private float normal;
	
	void Start()
	{
       
		//normal = cam.fieldOfView;
		zoom = 20;
	}

	void Awake()
	{
		cam = GameObject.Find("MainCamera").GetComponent<Camera>();
	}
		
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButton(1))
		{
			//cam.fieldOfView = zoom;
		}
		else
		{
			//cam.fieldOfView = normal;
		}
		

	}
}
