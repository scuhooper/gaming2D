/*********
 *		Author: James Keeling
 *		Purpose: This server to create a line/ray from the player to the mouse, 
 *				 show a mostly see-through player at the end of the line for where they will be placed after the teleport, 
 *				 and setting the player at the end of the line on their input.
 ********/

using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public float maxTeleportDistance;

	LineRenderer line;  // linerenderer component
	Vector3 mousePos;   // used for the coordinate to represent the mouse pointer on the screen
	GameObject playerProjection;	// projection of where to teleport to

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
		line.useWorldSpace = true;	// make renderer use world space coordinates
		line.SetWidth( .05f, .05f );    // width of line !!!BEWARE!!! small values still produce rather large lines

		playerProjection = transform.GetChild( 1 ).gameObject;   // get reference to projection object
	}
	
	// Update is called once per frame
	void Update () {
		DrawLine();
		if ( Input.GetKeyDown( KeyCode.Space ) )
		{
			GetComponentInParent<Transform>().position = playerProjection.transform.position;
		}
	}


	void DrawLine()
	{
		// Get line vector for teleport direction ray
		GetLineVector();
		// set up line properties
		SetupLinePoints();
		// set projected Barry image to end of line
		ShowProjectedImage();
	}
	/// <summary>
	/// Gets the world coordinates of the mouse pointer
	/// </summary>
	void GetMousePosition()
	{
		// get mouse position for setting the endpoint of the line
		mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		mousePos.z = -1f;  // adjusted z value to make it always show in front of other elements
	}

	/// <summary>
	/// Get a normalized line vector to be added to the player transform to show where a teleport could be used
	/// </summary>
	void GetLineVector()
	{
		// Get world coordinates of the mouse pointer - used to set end point of teleport line
		GetMousePosition();

		// make a vector of the differences between positions and normalize it - allows us to easily add vector * magnitude to set up endpoint
		Vector3 normalizeVector = new Vector3( mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0f );
		normalizeVector.Normalize();

		float currentDistance = Vector3.Distance( transform.position, mousePos );	// distance between transform and mouse pointer
		if ( currentDistance > maxTeleportDistance )	// if distance is greater than our max teleportable distance...
		{
			// this sets the vector to have the magnitude of our max distance
			normalizeVector.x *= maxTeleportDistance;
			normalizeVector.y *= maxTeleportDistance;
			normalizeVector.z = -1f;
			// set mousePos to our new 
			mousePos = normalizeVector;	
		}
		else
		{
			// sets magnitude to original magnitude of vector
			normalizeVector.x *= currentDistance;
			normalizeVector.y *= currentDistance;
			normalizeVector.z = -1f;
			// set mousePos to be the new vector
			mousePos = normalizeVector;
		}
	}

	/// <summary>
	/// Set beginning and end line points
	/// </summary>
	void SetupLinePoints()
	{
		line.SetPosition( 0, transform.position );  // beginning of line
		line.SetPosition( 1, new Vector3( transform.position.x + mousePos.x, transform.position.y + mousePos.y, transform.position.z ) );   // end of line
		line.enabled = true;    // make line visible
	}

	/// <summary>
	/// Display the semi-transparent player at the end of the teleporter line
	/// </summary>
	void ShowProjectedImage()
	{
		// set projected Barry image to end of line
		playerProjection.SetActive( true ); // enable the object
		playerProjection.transform.position = new Vector3( transform.position.x + mousePos.x, transform.position.y + mousePos.y, -1f ); // set object to be centered at mouse location
	}
}
