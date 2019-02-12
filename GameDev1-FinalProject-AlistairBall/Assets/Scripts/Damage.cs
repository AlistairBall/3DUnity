using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {


    public int basicHealth;
    public int specialHealth;

    public GameObject Spawner;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c)
    {
        //Destroy(c.gameObject);

        if (c.gameObject.tag == "Projectile" || c.gameObject.tag == "Pellet" && gameObject.tag == "basicEnemy")
        {
            basicHealth--;


        }
        else if (basicHealth == 0)
        {
            Instantiate(Spawner, transform.position, Quaternion.identity);
            Spawner.SetActive(true);
            Destroy(gameObject);
        }

        if (c.gameObject.tag == "Projectile" || c.gameObject.tag == "Pellet" && gameObject.tag == "specialEnemy")
        {
            specialHealth--;
        }

        else if (gameObject.tag == "specialEnemy" && specialHealth == 0)
        {
            
            Instantiate(Spawner, c.transform.position, Quaternion.identity);
            Spawner.SetActive(true);
            Destroy(gameObject);
        }
    }
 }
