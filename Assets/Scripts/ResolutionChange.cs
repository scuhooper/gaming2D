using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System.Collections.Generic;
using System;

/// <summary>
/// Allows the changing of screen resolution while in game through the menus
/// </summary>
public class ResolutionChange : MonoBehaviour {
	
    public Dropdown ResolutionD; //UI dropdown menu
    Resolution[] resolutions; //Array for storing possible screen resolutions


    private void Start()
    {
        resolutions = Screen.resolutions; //Gets all possible screen resolutions for monitor

        //Loops through all possible screen resolutions and adds delegates listening for changes to the resolution of the game
        for (int i = 0; i < resolutions.Length; i++)
        {
            ResolutionD.options.Add(new Dropdown.OptionData(ResToString(resolutions[i])));

            ResolutionD.value = i;

            ResolutionD.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[ResolutionD.value].width, resolutions[ResolutionD.value].height, true); });
        }

    }
    private void Update()
    {
       // Debug.Log("isChecked is " + isChecked);
    }

    /// <summary>
    /// This adds easy to read strings for the resolution you're selecting
    /// </summary>
    /// <param name="resolution"></param>
    /// <returns></returns>
    private string ResToString(Resolution resolution)
    {
        return resolution.width + " X " + resolution.height;
    }
}
