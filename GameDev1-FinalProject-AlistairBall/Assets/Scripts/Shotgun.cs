using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour {

    public Transform player;

    public Rigidbody pelletPrefab;

    public Rigidbody pellet;
        float BulletSpread = 8.0f;
        float pelletSpeed = 70f;
        int pelletCount = 8;
        float fireRate = 0.5f;
       float nextFire = 0.0f;
  public  Transform ProjectileSpawn;

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && player.GetComponent<PlayerControler>().shotgunAmmo >= 0)
        {
            player.GetComponent<PlayerControler>().shotgunAmmo--;
            player.GetComponent<PlayerControler>().AmmoText.text = "Ammo: " + player.GetComponent<PlayerControler>().shotgunAmmo.ToString();

            for (var i = 0; i < pelletCount; i++)
            {
                var pelletRot = transform.rotation;
                pelletRot.x = Random.Range(-BulletSpread, BulletSpread);
                pelletRot.y = Random.Range(-BulletSpread, BulletSpread);
                pellet = Instantiate(pelletPrefab, ProjectileSpawn.position, pelletRot);
                pellet.velocity = transform.forward * pelletSpeed;

                

              
            }
            nextFire = Time.time + fireRate;
        }
        

    }

    void OnCollisionEnter()
    {
     
    }

   

}

