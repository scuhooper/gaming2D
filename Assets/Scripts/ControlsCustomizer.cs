/*********
 *		Author:  James Keeling
 *		Purpose: Provide the basic framework for customizing a players controls. This script will need to be placed on the game logic object
 *				 that is used to handle the main menu and pause menu in each scene. This script also makes calls to the Player script and will
 *				 need to be updated if the Player script is changed
 ********/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlsCustomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// This coroutine will wait for user input then update their control mappings with the next button pressed. If button is escape, it cancels the coroutine.
	/// </summary>
	/// <param name="p">Player who's controls are being adjusted</param>
	/// <param name="currentButton">Button that called this function</param>
	/// <returns></returns>
	public IEnumerator WaitForInput( Player p, GameObject currentButton )
	{
		while ( !Input.anyKeyDown ) // wait until an input is detected
		{
			yield return null;
		}

		foreach ( KeyCode code in Enum.GetValues( typeof( KeyCode ) ) ) // cycle through the KeyCode enum to check what key has been pressed
		{
			if ( Input.GetKey( code ) ) // check to see if this is the right key being pressed
			{
				if ( code == KeyCode.Escape )	// leave if button is escape
					break;

				currentButton.GetComponentInChildren<Text>().text = code.ToString();	// set the text of the button to reflect the new button's name
				p.ChangeControls( currentButton.name, code );   // map the new code to the player's controls dictionary
			}
		}
	}
	/// <summary>
	/// Saves a player's control mappings to a file.
	/// </summary>
	/// <param name="p">Which player's controls to save</param>
	public void UpdatePlayerConfigFile( Player p )
	{
		p.SaveControlsToFile();	// call the specific player's function to save their controls to their config file
	}
}
