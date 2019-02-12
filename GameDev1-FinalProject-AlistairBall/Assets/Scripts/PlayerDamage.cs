using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    public Image healthBar;
    public int health = 200;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Projectile" || c.gameObject.tag == "Pellet")
        {
            health -= 20;

            
        }
    }
}
