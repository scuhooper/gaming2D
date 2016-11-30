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

	LineRenderer line;	// linerenderer component

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
		line.useWorldSpace = true;	// make renderer use world space coordinates
		line.SetWidth( .1f, .1f );	// width of line !!!BEWARE!!! small values still produce rather large lines
	}
	
	// Update is called once per frame
	void Update () {
		// get mouse position for setting the endpoint of the line
		Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		mousePos.z = -10f;  // adjusted z value to make it always show in front of other elements

		// check if distance between player and mouse is larger than max teleport distance
		

		// set up line properties
		line.SetPosition( 0, transform.position );	// beginning of line
		line.SetPosition( 1, new Vector3( mousePos.x, mousePos.y, transform.position.z ) );	// end of line
		line.enabled = true;    // make line visible

		// set projected Barry image to end of line
		GameObject playerProjection = transform.GetChild( 0 ).gameObject;	// get reference to projection object
		playerProjection.SetActive( true );	// enable the object
		playerProjection.transform.position = new Vector3( mousePos.x, mousePos.y, -1f );	// set object to be centered at mouse location
	}
}
