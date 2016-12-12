//Cory Brown
//IST360
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {


	public Button playButton ;
	//public Button controlButton;
	//public Button optionButton;
	public Button exitButton;

	//bool playPress;
	//bool controlPress;
	//bool optionPress;
	//bool exitPress;

void Start()
{
	playButton = playButton.GetComponent<Button>();
	//controlButton = controlButton.GetComponent<Button>();
	//optionButton = optionButton.GetComponent<Button>();
	exitButton = exitButton.GetComponent<Button>();

}
public void PressPlay(){
	SceneManager.LoadScene("Scene1");

	}

public void ExitPress(){
		Application.Quit();
	}
}
