/*********
 *		Author:Cameron Asbury 
 *		Purpose:Pauses the game, as well shows a menu of options.
 ********/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	List<Player> playerList = new List<Player>();	// list to hold all players in game

	// editor hooks for variables
    public Canvas pauseCanvas;
	public GameObject cardboardSign;
	public GameObject pauseMenuButtons;
	public GameObject controlsMenu;
	public GameObject playerMenu;
	public GameObject customControlMenu;
	public Text[] customControlsText;

    bool isPaused;	// is the game paused
	
	Player p;	// holds which player's controls are being changed
	ControlsCustomizer contCustom;	// gets the script component

	// Use this for initialization
	void Start () {
		foreach ( Player p in FindObjectsOfType<Player>() )	// initialize list
		{
			playerList.Add( p );
		}

        pauseCanvas.enabled = false;	// set pause menu to be inactive
		// initialize variables
        isPaused = false;
		contCustom = GetComponent<ControlsCustomizer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))	// pause button is pressed
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
			}

            Time.timeScale = 0;	// pause updates
        }
        else
        {
            pauseCanvas.enabled = false;

			// cycle through list and enable player and teleport components
			foreach ( Player p in playerList )
			{
				p.enabled = true;
			}

            Time.timeScale = 1;	// restarts game timers
        }
    }

	/**********
	 *	This has been changed by James to be able to run the customizable controls. Any questions please direct them to him 
	 * ********/

	public void OnControlsButtonClick()
	{
		StartCoroutine( TurnCardboard() );	// flip the screen image and enable the correct menu
	}

	public void OnOptionsButtonClick()
	{

	}

	public void OnQuitButtonClick()
	{
		Application.Quit();	// exit game
	}

	public void OnPlayerButtonClick()
	{
		string playerName = EventSystem.current.currentSelectedGameObject.gameObject.GetComponentInChildren<Text>().text.ToLower();	// gets the players name by reading the text from the button that was clicked
		string[] tempArr = playerName.Split( ' ' );	// break into strings with space as delimiter
		playerName = tempArr[ 0 ] + tempArr[ 1 ];	// combine strings again to form the players correct name in the scene

		p = GameObject.Find( playerName ).GetComponent<Player>();	// find the game object with the player's name and grab its player component
		playerMenu.SetActive( false );	// hide the player menu
		ShowControlButtonMappings( p );	// load the dictionary for selected player
		customControlMenu.SetActive( true );	// show the control customization menu
	}

	public void OnCustomControlButtonClick()
	{
		GameObject currentButton = EventSystem.current.currentSelectedGameObject;	// grab the gameobject of the button clicked
		StartCoroutine( contCustom.WaitForInput( p, currentButton ) );	// send the button and current player being edited to customize that control
	}

	public void OnBackButtonClick()
	{
		// if the player menu is being used
		if ( playerMenu.activeInHierarchy )
			StartCoroutine( TurnCardboard() );  // rotate the cardboard back to regular pause menu
		else
		{
			// control menu is showing

			p.SaveControlsToFile();	// save the players controls to their corresponding file
			customControlMenu.SetActive( false );	// hide the control customization menu
			playerMenu.SetActive( true );	// show the player menu
		}
	}

	/// <summary>
	/// Displays the key name of the selected player's button mappings
	/// </summary>
	/// <param name="player">Player's controls to show</param>
	void ShowControlButtonMappings( Player player )
	{
		int count = 0;	// acts as an iterator

		// cycle through dictionary of player
		foreach ( KeyValuePair<string, KeyCode> pair in player.GetControlMappings() )
		{
			customControlsText[ count ].text = pair.Value.ToString();	// change the text of the control button to mirror the key name from the player's dictionary
			count++;	// increment count
		}
	}

	/// <summary>
	/// Rotates the cardboard image and swaps between the pause menu and the controls menu
	/// </summary>
	/// <returns></returns>
	IEnumerator TurnCardboard()
	{
		if ( cardboardSign.transform.rotation.eulerAngles == Vector3.zero )	// if sign rotation is 0
		{
			float angle = 0f;	// set initial angle by which to rotate
			while ( angle != 180 )	// do until is is at 180 
			{
				angle += 5;	// increment angle by 5 degrees
				if ( angle == 90 )	// change what is active at 90 degrees, makes it appear to only be written on one side of the sign
				{
					pauseMenuButtons.SetActive( false );
					controlsMenu.SetActive( true );
					playerMenu.SetActive( true );
				}
				cardboardSign.transform.rotation = Quaternion.Euler( 0, angle, 0 );	// update the rotation of the sign
				yield return null;
			}
		}
		else
		{
			// if sign is at something other than 0
			float angle = 180;	// make angle now 180 as a starting point
			while ( angle != 0 )	// rotate until it is back to 0 rotation
			{
				angle -= 5;	// decrement angle by 5
				if ( angle == 90 )  // change what is active at 90 degrees, makes it appear to only be written on one side of the sign
				{
					pauseMenuButtons.SetActive( true );
					controlsMenu.SetActive( false );
					playerMenu.SetActive( false );
				}
				cardboardSign.transform.rotation = Quaternion.Euler( 0, angle, 0 );	// update the rotation of the sign
				yield return null;
			}
		}
	}
}
