// BasicFPSController
// Ryan H. Berriualt
// ESC brings up hidden Canvas and pauses game clock.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCPauseMenu : MonoBehaviour 
{

	// Varribles
	public Canvas GUI;
	public Canvas UI;
	public bool Paused = false;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			// Lock Cursor to center of the screen unless ESC
			// Also switch canvas's, Freeze time and Freeze Controls 
			if (Input.GetKey(KeyCode.Escape)) 
			{
				// Switch pasued
				Paused = !Paused;

				if(Paused)
				{
					UI.enabled = (true);
					GUI.enabled = (false);	
					Time.timeScale = 0; 
				}
				else if(!Paused)
				{
					Time.timeScale = 1; 
					GUI.enabled = (true);
					UI.enabled = (false);
				}

			}
		}
	}
}
