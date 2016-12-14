/*********
 *		Author: James Keeling
 *		Purpose: Provide the basic framework for the player and player movement. Also used by all drug/powerup scripts.
 ********/
 
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class Player : MonoBehaviour
{

	public float speed = 10.0F;
	public GameObject hitBox;
	private Animator animator;

	// variables used for combat and damage. These are accessed in some of the drug scripts.
	// Questions, ask James
	public float armor;
	public int damage;

	public string configFileName = "player1controls.ini";	// default config file name. this will just mimic player1's input on all players

	Dictionary<string, KeyCode> controlMappings = new Dictionary<string, KeyCode>();	// hashtable for storing the generic strings describing what function happens with the keycode representing the button pressed

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		hitBox.SetActive(false);
	}

	private void Awake()
	{
		GetConfigFile();	// must be here as it is not calling correctly in start
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// Movement for characters
		Vector3 moveVector = Vector3.zero;	// movement vector to add to the player position. allows for us to move in diagonals, but not make it faster than moving only in one direction
		
		// reads from Dictionary to get correct button names
		if ( Input.GetKey( controlMappings[ "up" ] ) )
			moveVector += Vector3.up;
		if ( Input.GetKey( controlMappings[ "down" ] ) )
			moveVector += Vector3.down;
		if ( Input.GetKey( controlMappings[ "left" ] ) )
			moveVector += Vector3.left;
		if ( Input.GetKey( controlMappings[ "right" ] ) )
			moveVector += Vector3.right;

		if ( Input.inputString != string.Empty )
			Debug.Log( Input.inputString );
		
		if ( moveVector == Vector3.zero )	// no movement happeneing, reset animator bool
		{
			animator.SetBool( "isWalking", false );
		}
		else
		{
			moveVector.Normalize();	// set the value of the direction moving to 1 unit
			if ( Input.GetKey( controlMappings[ "sprint" ] ) )	// figure out if we are trying to sprint
				transform.position += moveVector * speed * 2 * Time.deltaTime;	// double speed
			else
				transform.position += moveVector * speed * Time.deltaTime;	// regular running
			animator.SetBool( "isWalking", true );	// make sure animator is set to moving
		}

		//Attack
		if ( Input.GetMouseButtonDown(0))
		{
			hitBox.SetActive(true);
		}
		else {
			hitBox.SetActive(false);
		}
	}

	/// <summary>
	/// Creates or Opens a file from which to read the input for a given player
	/// </summary>
	void GetConfigFile()
	{
		// opening file and reading stream
		FileStream fstream = new FileStream( configFileName, FileMode.OpenOrCreate );
		StreamReader fin = new StreamReader( fstream );

		List<string> linesFromFile = new List<string>();	// a list to hold the lines from the file as strings

		while ( !fin.EndOfStream )	// run until end of file
		{
			linesFromFile.Add( fin.ReadLine() );	// add each line to linesFromFile
		}

		// cycle through lines from the file and translate into Dictionary
		foreach ( string str in linesFromFile )
		{
			str.Trim( '\n' );	// remove new line characters
			string[] tempArr = str.Split( '=' );    // uses = as the delimiter to break string into parts
			
			// create dictionary entry for current line
			controlMappings.Add( tempArr[ 0 ], 
				(KeyCode)Enum.Parse(typeof(KeyCode), tempArr[1]) );	// this line searches the KeyCode enum to match the string value from the file to it's corresponding enum value
		}

		// close file and reading stream
		fin.Close();
		fstream.Close();
	}

	/// <summary>
	/// Updates the dictionary entry for a control
	/// </summary>
	/// <param name="controlName">Control name to be updated</param>
	/// <param name="key">New key to associate with control</param>
	public void ChangeControls( string controlName, KeyCode key )
	{
		controlMappings[ controlName ] = key;
	}

	public Dictionary<string, KeyCode> GetControlMappings()
	{
		return controlMappings;
	}

	public void SaveControlsToFile()
	{
		// open file and writing stream
		FileStream fstream = new FileStream( configFileName, FileMode.Truncate );
		StreamWriter fout = new StreamWriter( fstream );

		int count = 1;
		foreach ( KeyValuePair<string, KeyCode> pair in controlMappings )
		{
			if ( count < controlMappings.Count )
			{
				fout.WriteLine( pair.Key + "=" + pair.Value.ToString() );
				count++;
			}
			else
				fout.Write( pair.Key + "=" + pair.Value.ToString() );
		}

		fout.Flush();
		fout.Close();
		fstream.Close();
	}
}
