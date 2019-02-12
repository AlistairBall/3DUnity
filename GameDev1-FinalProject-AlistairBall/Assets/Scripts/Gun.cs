// BasicFPSController
// Ryan H. Berriualt
// Gun Parent Class.

using UnityEngine;

public class Gun : MonoBehaviour 
{
	public float damage;
	public float range;
    public float impactForce;
	public float fireRate;
	private float nextTimeToFire = 0.0f;
	public ParticleSystem mf;
	public GameObject fpsCam;
	public GameObject impact;

	void Awake()
	{
		fpsCam = GameObject.Find("MainCamera");
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
		{
			Fire();
			nextTimeToFire = Time.time + 1f/fireRate;
		}
	}

	void Fire()
	{	
		mf.Play();

		RaycastHit hit;
		if( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) )
		{
			//Debug.Log(hit.transform.name);

			Health target  = hit.transform.GetComponent<Health>();
			if(target != null)
			{
				if(hit.transform.tag != "Player"){target.TakeDamage(damage);}
			}

			if(hit.rigidbody !=null)
			{
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}

			GameObject impactGo = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGo, 2.0f);
		}
	}
}
