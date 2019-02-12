using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour {

    public Projectile projectilePrefab;
    public Transform projectileSpawnPoint;
    public Transform player;

    // Use this for initialization
    void Start () {

        if (!projectilePrefab)
            Debug.LogError("Projectile Prefab not set.");
        if (!projectileSpawnPoint)
            Debug.LogError("ProjectileSpawnPoint not set.");

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 SpawnPoint = new Vector3(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y, projectileSpawnPoint.position.z);
        if (Input.GetMouseButtonDown(0))
        {

            Projectile temp = Instantiate(projectilePrefab,
             SpawnPoint, projectileSpawnPoint.rotation);
         


        }
      

    }
}
