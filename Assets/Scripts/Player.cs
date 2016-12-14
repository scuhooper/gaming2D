using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class Player : MonoBehaviour
{

	public float speed = 10.0F;
	//public bool isWalking;
	public GameObject hitBox;
	public float Speed = 1f;
	private float movex = 0f;
	private float movey = 0f;
	private Animator animator;
	public double run = 1.5;

	// variables used for combat and damage. These are accessed in some of the drug scripts.
	// Questions, ask James
	public float armor;
	public int damage;

	public string configFileName = "player1controls.ini";

	Dictionary<string, string> controlMappings = new Dictionary<string, string>();

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		hitBox.SetActive(false);
		GetConfigFile();
	}

	private void Awake()
	{
		GetConfigFile();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//GetConfigFile();
		////Movement
		//movex = Input.GetAxis( "Horizontal" );
		//movey = Input.GetAxis( "Vertical" );
		//GetComponent<Rigidbody2D>().velocity = new Vector2( movex * Speed, movey * Speed );

		//if ( Input.GetKey( "left shift" ) )
		//{
		//	GetComponent<Rigidbody2D>().velocity = new Vector2( movex * Speed * 2, movey * Speed * 2 );
		//}
		//else
		//{
		//	GetComponent<Rigidbody2D>().velocity = new Vector2( movex * Speed, movey * Speed );
		//}




		Vector3 moveVector = Vector3.zero;

		if ( Input.GetKey( controlMappings[ "up" ] ) )
			moveVector += Vector3.up;
		if ( Input.GetKey( controlMappings[ "down" ] ) )
			moveVector += Vector3.down;
		if ( Input.GetKey( controlMappings[ "left" ] ) )
			moveVector += Vector3.left;
		if ( Input.GetKey( controlMappings[ "right" ] ) )
			moveVector += Vector3.right;
		
		if ( moveVector == Vector3.zero )
		{
			animator.SetBool( "isWalking", false );
		}
		else
		{
			moveVector.Normalize();
			if ( Input.GetKey( controlMappings[ "sprint" ] ) )
				transform.position += moveVector * speed * 2 * Time.deltaTime;
			else
				transform.position += moveVector * speed * Time.deltaTime;
			animator.SetBool( "isWalking", true );
		}


		//Attack
		if ( Input.GetMouseButtonDown(0))
		{
			hitBox.SetActive(true);
		}
		else {
			hitBox.SetActive(false);
		}

		//flips the player left and right
		if (movex <= -0.1f)
		{
			// transform.rotation = Quaternion.Euler(0, 180, 0); **Changed by James. Flipping sprite makes using the transform of player in Teleport.cs easier to manage.**
			GetComponent<SpriteRenderer>().flipX = true;
		}
		if (movex >= 0.1f)
		{
			// transform.rotation = Quaternion.Euler(0, 0, 0); **Changed by James. Flipping sprite makes using the transform of player in Teleport.cs easier to manage.**
			GetComponent<SpriteRenderer>().flipX = false;
		}
	}


	void GetConfigFile()
	{
		Debug.Log( "Making config file!" );
		FileStream fstream = new FileStream( configFileName, FileMode.OpenOrCreate );
		StreamReader fin = new StreamReader( fstream );

		List<string> linesFromFile = new List<string>();

		while ( !fin.EndOfStream )
		{
			linesFromFile.Add( fin.ReadLine() );
		}

		foreach ( string str in linesFromFile )
		{
			str.Trim( '\n' );
			string[] tempArr = str.Split( '=' );
			foreach ( string s in tempArr )
				Debug.Log( "'" + s + "'" );
			controlMappings.Add( tempArr[ 0 ], tempArr[ 1 ] );
		}

		fin.Close();
		fstream.Close();
	}
}
