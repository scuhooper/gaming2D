using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	LineRenderer line;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
		line.useWorldSpace = true;
		// line.SetColors( Color.yellow, Color.yellow );
		line.SetWidth( .1f, .1f );
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		mousePos.z = -10;
		// Debug.Log( mousePos.ToString() );

		line.SetPosition( 0, transform.position );
		line.SetPosition( 1, mousePos );
		line.enabled = true;
		// Debug.DrawLine( transform.position, mousePos, Color.yellow, 0, false );
	}
}
