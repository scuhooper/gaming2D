/*********
 *		Author:  James Keeling
 *		Purpose: Provide the basic framework for customizing a players controls. This script will need to be placed on the game logic object
 *				 that is used to handle the main menu and pause menu in each scene. This script also makes calls to the Player script and will
 *				 need to be updated if the Player script is changed
 ********/

 using System;
using UnityEngine;

public class ControlsCustomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// This function sets the key for a particular player's control to be changed to a value other than Escape.
	/// </summary>
	/// <param name="p">Which Player's controls to modify</param>
	/// <param name="controlName">Control name to be modified</param>
	void CustomizeControl( Player p, string controlName )
	{
		KeyCode keyCode = GetKeyPressed();	// need the keycode for what was pressed - call function from this file to get it
		if ( keyCode == KeyCode.Escape )	// key cannot be escape as it is used for the menu and as an exit case from the get key pressed function
			return;	// if this happens, just exit the funciton leaving everything as is

		p.ChangeControls( controlName, keyCode );	// pass in a valid key to change the dictionary entry
	}

	/// <summary>
	/// Function returns the key code of whatever key is pressed.
	/// </summary>
	/// <returns>Returns either the key code pressed or Escape if an invalid key code is given</returns>
	KeyCode GetKeyPressed()
	{
		while ( !Input.anyKey )	// wait until an input is detected
			continue;

		foreach ( KeyCode code in Enum.GetValues( typeof( KeyCode ) ) )	// cycle through the KeyCode enum to check what key has been pressed
		{
			if ( Input.GetKey( code ) )	// check to see if this is the right key being pressed
			{
				return code;	// return that key code if so
			}
		}
		return KeyCode.Escape;	// exit condition of an invalid entry - Customize Control should check for this condition
	}

	/// <summary>
	/// Saves a player's control mappings to a file.
	/// </summary>
	/// <param name="p">Which player's controls to save</param>
	void UpdatePlayerConfigFile( Player p )
	{
		p.SaveControlsToFile();	// call the specific player's function to save their controls to their config file
	}
}
