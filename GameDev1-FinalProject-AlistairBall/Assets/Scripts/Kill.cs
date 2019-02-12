using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public GameObject Spawner;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c)
    {
        if (gameObject.tag != "Pellet")
        {
            Destroy(gameObject);

        }

       
    }
}
