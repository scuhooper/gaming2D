using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System.Collections.Generic;
using System;

public class ResolutionChange : MonoBehaviour {

    //   public int width;
    //   public int height;
    //   public Dropdown resolutionSelection;
    //   public GameObject menu;

    //   // Use this for initialization
    //   void Start () {

    //}


    //// Update is called once per frame
    //void Update () {

    //       if (menu.active == true)
    //       {
    //           if (resolutionSelection.value == 0)
    //           {
    //               setResolution
    //           }
    //       }

    //}

    //   public void setResolution(int width, int height)
    //   {
    //       Screen.SetResolution(width, height, true);
    //   }

    public Dropdown ResolutionD;
    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            ResolutionD.options.Add(new Dropdown.OptionData(ResToString(resolutions[i])));

            ResolutionD.value = i;

            ResolutionD.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[ResolutionD.value].width, resolutions[ResolutionD.value].height, true); });
        }

    }

    private string ResToString(Resolution resolution)
    {
        return resolution.width + " X " + resolution.height;
    }
}
