/*********
 *		Author:Cameron Asbury 
 *		Purpose:Pauses the game, as well shows a menu of options.
 ********/
using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    GameObject player1;
    GameObject player2;
    public Canvas pauseCanvas;
    bool isPaused;

	// Use this for initialization
	void Start () {
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        pauseCanvas.enabled = false;
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {

            pauseCanvas.enabled = true;
            
            player1.GetComponent<LeftPlayer>().enabled = false;
            player1.GetComponent<Teleport>().enabled = false;
            player2.GetComponent<RightPlayer>().enabled = false;
            player2.GetComponent<Teleport>().enabled = false;
            Time.timeScale = 0;
        }
        else
        {

            pauseCanvas.enabled = false;

            player1.GetComponent<Teleport>().enabled = true;
            player1.GetComponent<LeftPlayer>().enabled = true;
            player2.GetComponent<RightPlayer>().enabled = true;
            player2.GetComponent<Teleport>().enabled = true;
            Time.timeScale = 1;
        }
    }
}
