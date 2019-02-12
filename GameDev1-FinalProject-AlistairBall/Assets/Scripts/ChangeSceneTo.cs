// BasicFPSController
// Ryan H. Berriualt
// Changes scene to given index.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTo : MonoBehaviour 
{
	public void SwitchTo(int index)
	{
		SceneManager.LoadScene(index);
	}
}
