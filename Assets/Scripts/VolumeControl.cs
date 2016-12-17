using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Volume Control Script for Options Menus in Game.
/// </summary>
public class VolumeControl : MonoBehaviour {

    public Slider volumeSlider; //SLider for volume
    public AudioSource masterSound; //Master sound for current scene

	// Use this for initialization
	void Start () {
        masterSound.volume = PlayerPrefs.GetFloat("Volume Control"); //Saves preferences to registry file
        volumeSlider.value = masterSound.volume;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

  
}
