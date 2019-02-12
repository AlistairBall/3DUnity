// BasicFPSController
// Ryan H. Berriualt
// Just Basic Health componet

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
	public float MaxHP;
	public float currentHP;
	public bool dead;

	void Start () 
	{
		currentHP = MaxHP;
	}

	public void TakeDamage(float change)
	{
		if (currentHP <= change)
		{
			Die();
		}
		else 
		{
		  currentHP = currentHP - change;
		}
	}

	public void Die()
	{
		Debug.Log(gameObject + ": Has Died.");
		Destroy(gameObject);
	}
}
