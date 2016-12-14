/*********
 *		Author:Cameron Asbury 
 *		Purpose:Pauses the game, as well shows a menu of options.
 ********/
using UnityEngine;
using System.Collections.Generic;

public class PauseScript : MonoBehaviour {

	List<Player> playerList = new List<Player>();	// list to hold all players in game
    public Canvas pauseCanvas;
    bool isPaused;

	// Use this for initialization
	void Start () {
		foreach ( Player p in FindObjectsOfType<Player>() )	// initialize list
		{
			playerList.Add( p );
		}
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

			// cycle through list and disable player and teleport components
			foreach ( Player p in playerList )
			{
				p.enabled = false;
				p.GetComponent<Teleport>().enabled = false;
			}
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.enabled = false;

			// cycle through list and enable player and teleport components
			foreach ( Player p in playerList )
			{
				p.enabled = true;
				p.GetComponent<Teleport>().enabled = true;
			}
            Time.timeScale = 1;
        }
    }
}
