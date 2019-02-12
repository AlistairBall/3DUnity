// BasicFPSController
// Ryan H. Berriualt
// Exit To Desktop.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToDesktop : MonoBehaviour
{
	public void ExitProgram()
	{
		 #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
		Debug.Log("Program Terminated");
	}
}
