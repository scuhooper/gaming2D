//Cory Brown
//IST360
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	void Start()
	{

	}
	public void PressPlay(){
		SceneManager.LoadScene( "Scene1" );
		}

	public void ExitPress(){
			Application.Quit();
		}
}
