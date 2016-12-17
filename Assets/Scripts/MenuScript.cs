using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public GameObject cardboardSign; //Cardboard Sign Background for Title Screen Background
    public AudioSource masterSound; //Title Screen Audio
    public Slider soundSlider; //Sliderbar on the Options menu

    void Start()
	{
		cardboardSign.SetActive( false );
	}
    /// <summary>
    /// Play Button on Title Screen Function
    /// </summary>
	public void PressPlay(){
		SceneManager.LoadScene( "Scene1" );
		}

    /// <summary>
    /// Exit Button on Title Screen
    /// </summary>
	public void ExitPress(){
			Application.Quit();
		}

    /// <summary>
    /// Options Button on Title Screen
    /// </summary>
    public void OptionsPress()
    {
		cardboardSign.SetActive( true );
	}

    /// <summary>
    /// Back button on options menus from title screen
    /// </summary>
	public void BackButton()
    {
		cardboardSign.SetActive( false );
        
    }

    /// <summary>
    /// Controls Button from Title Screen
    /// </summary>
    public void ControlsPress()
    {
        
    }

    private void Update()
    {
        masterSound.volume = soundSlider.value;
        PlayerPrefs.SetFloat("Volume Control", masterSound.volume);
        PlayerPrefs.Save();
    }
}
