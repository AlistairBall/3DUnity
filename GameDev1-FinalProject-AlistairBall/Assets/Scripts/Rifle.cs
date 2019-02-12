using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour {

    public Transform player;

    public Projectile projectilePrefab;
    public Transform projectileSpawnPoint;

    float nextFire = 0.0f;
    float fireRate = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 SpawnPoint = new Vector3(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y, projectileSpawnPoint.position.z);
        if (Input.GetMouseButton(0) && Time.time > nextFire && player.GetComponent<PlayerControler>().rifleAmmo >= 0)
        {
            
            Projectile temp = Instantiate(projectilePrefab,
             SpawnPoint, projectileSpawnPoint.rotation);
            player.GetComponent<PlayerControler>().rifleAmmo--;
            player.GetComponent<PlayerControler>().AmmoText.text = "Ammo: " + player.GetComponent<PlayerControler>().rifleAmmo.ToString();
            nextFire = Time.time + fireRate;


        }
    }
}
