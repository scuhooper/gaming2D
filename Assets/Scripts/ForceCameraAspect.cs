/*********
 *		Author:Cameron Asbury 
 *		Purpose:Force Camera into a selected aspect ratio, so no matter what screen resolution a player picks on screen artifacts all remain the same. 
 *		citations:http://gamedesigntheory.blogspot.ie/2010/09/controlling-aspect-ratio-in-unity.html
 ********/
using UnityEngine;
using System.Collections;

public class ForceCameraAspect : MonoBehaviour {

    public float numerator; //Public nnumerator and denominator to allow quick changing of forced aspect
    public float denominator;
    float targetAspect; //Aspect ratio you want
    float currentAspect; //current windows aspect ratio
    float scaleAspectHeight; //Scales the height of the window
    float scaleAspectWidth; //Scales the Width of the window
    
    
    // Use this for initialization
    void Start()
    {
        ForceAspect();
    }

    // Update is called once per frame
    void Update()
    {
        ForceAspect();
    }

    //Function for force the aspect ratio to be what the developer decides not Unity
    private void ForceAspect()
    {


        targetAspect = numerator / denominator;
        currentAspect = (float)Screen.width / (float)Screen.height;
        scaleAspectHeight = currentAspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleAspectHeight < 1.0f)//Adds Letterboxes if our scaled height is less than the current height
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleAspectHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleAspectHeight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            scaleAspectWidth = 1.0f / scaleAspectHeight;

            Rect rect = camera.rect;

            rect.width = scaleAspectWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleAspectWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }


    }

}
  
    
    
   

