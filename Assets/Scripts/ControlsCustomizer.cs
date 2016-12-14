using System;
using System.Collections;
using System.Collections.Generic;
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
		KeyCode keyCode = GetKeyPressed();
		if ( keyCode == KeyCode.Escape )
			return;

		p.ChangeControls( controlName, keyCode );
	}

	/// <summary>
	/// Function returns the key code of whatever key is pressed.
	/// </summary>
	/// <returns>Returns either the key code pressed or Escape if an invalid key code is given</returns>
	KeyCode GetKeyPressed()
	{
		foreach ( KeyCode code in Enum.GetValues( typeof( KeyCode ) ) )
		{
			if ( Input.GetKey( code ) )
			{
				return code;
			}
		}
		return KeyCode.Escape;
	}

	/// <summary>
	/// Saves a player's control mappings to a file.
	/// </summary>
	/// <param name="p">Which player's controls to save</param>
	void UpdatePlayerConfigFile( Player p )
	{
		p.SaveControlsToFile();
	}
}
