using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour {

    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

    public float projectileForce;
    int ammo;
	// Use this for initialization
	void Start () {
        ammo = 20;

        projectileForce = 10.0f;
	}
	
	// Update is called once per frame
    public void Shoot()
    {
        if(ammo > 0)
        {
            Rigidbody temp = Instantiate(projectilePrefab,
                projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            temp.AddRelativeForce(projectileSpawnPoint.forward * projectileForce,
                ForceMode.Impulse);

            ammo--;
        }
    }

    public void GrenadeLaunch()
    {
        Rigidbody temp = Instantiate(projectilePrefab,
               projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        temp.AddRelativeForce(projectileSpawnPoint.forward * projectileForce,
                ForceMode.Impulse);


    }
}
