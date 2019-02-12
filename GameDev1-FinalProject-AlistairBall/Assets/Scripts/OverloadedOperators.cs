using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadedOperators : MonoBehaviour
{
    // Var
    Supplies a;
    Supplies b;
    Supplies abCombo;

    // Initialization ( On Create )
    void Start ()
    {
        a = new Supplies(4);
        b = new Supplies(6);
        abCombo = a + b;
        Debug.Log(abCombo.weight);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
