using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource masterSound;

	// Use this for initialization
	void Start () {
        //print(PlayerPrefs.GetFloat("Volume Control"));
        masterSound.volume = PlayerPrefs.GetFloat("Volume Control");
        volumeSlider.value = masterSound.volume;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

  
}
