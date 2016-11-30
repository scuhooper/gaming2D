using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    GameObject player;
    public Canvas pauseCanvas;
    bool isPaused;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
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
            
            player.GetComponent<Player>().enabled = false;
            //player.active = false;
            Time.timeScale = 0;
        }
        else
        {

            pauseCanvas.enabled = false;

            player.GetComponent<Player>().enabled = true;
            Time.timeScale = 1;
        }
    }
}
