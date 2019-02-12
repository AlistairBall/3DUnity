using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour 
{
	// Var
	public Transform SpawnBase;
	public GameObject HealthPrefab;
	
	public GameObject RiflePrefab;
    public GameObject ShotgunPrefab;

    private int ranInt;
	public string SpawnOption;
	public bool spawn;

	// Use this for initialization
	void Start () 
	{
		spawn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SpawnOption == "Random" && !spawn) {RandomSpawn(); spawn = true;}
		else if (SpawnOption == "Health"&& !spawn) {SpawnHealth(); spawn = true;}
		
		else if (SpawnOption == "Rifle"&& !spawn) { SpawnRifle(); spawn = true;}
        else if (SpawnOption == "Shotgun" && !spawn) { SpawnShotgun(); spawn = true; }


    }

    void OnDestroy()
    {
        
    }

	void RandomSpawn()
	{

		
		Random.seed = System.DateTime.Now.Millisecond;
		ranInt = Random.Range( 1 , 4);

		
		if(ranInt == 1) 
		{
			Instantiate(HealthPrefab, new Vector3( SpawnBase.transform.position.x, SpawnBase.transform.position.y +1 , SpawnBase.transform.position.z ), Quaternion.identity);
		}

		
		else if(ranInt == 2)
		{
			Instantiate(RiflePrefab, new Vector3( SpawnBase.transform.position.x, SpawnBase.transform.position.y +1 , SpawnBase.transform.position.z), Quaternion.identity);
		}

        else if (ranInt == 3)
        {
            Instantiate(ShotgunPrefab, new Vector3(SpawnBase.transform.position.x, SpawnBase.transform.position.y + 1, SpawnBase.transform.position.z), Quaternion.identity);
        }
    }

	void SpawnHealth()
	{
		
		Instantiate(HealthPrefab, new Vector3( SpawnBase.transform.position.x, SpawnBase.transform.position.y +1, SpawnBase.transform.position.z ), Quaternion.identity);
	}

	

	void SpawnRifle()
	{
		
		Instantiate(RiflePrefab, new Vector3( SpawnBase.transform.position.x, SpawnBase.transform.position.y +1, SpawnBase.transform.position.z ), Quaternion.identity);	
	}

    void SpawnShotgun()
    {

        Instantiate(ShotgunPrefab, new Vector3(SpawnBase.transform.position.x, SpawnBase.transform.position.y + 1, SpawnBase.transform.position.z), Quaternion.identity);
    }




}
