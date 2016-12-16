using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public GameObject BallSprite;
	public GameObject player1;
	public GameObject player2;
	public GameObject player1Spawn;
	public GameObject player2Spawn;
	public Transform BallSpawner;
	public float kickForce;

	God gameScript;
	
	void Start()
	{
		gameScript = FindObjectOfType<God>();
	}


	void Update()
	{

	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if ( col.gameObject.tag == "Goal" )	// check if trigger is a goal
		{
			if ( col.gameObject.name == "LeftGoal" )	// if left goal
			{
				//	update score text
				gameScript.AddScoreRight();
			}
			else if ( col.gameObject.name == "RightGoal" )
			{
				// update score
				gameScript.AddScoreLeft();
			}

			// reset players and ball
			ResetGameField();
		}
	}

	private void OnCollisionEnter2D( Collision2D collision )
	{
		// only care about collision if it is with player
		if ( collision.gameObject.tag == "player" )
		{
			// create a vector from the difference between the ball and players positions
			Vector2 forceToBall = new Vector2( transform.position.x - collision.gameObject.transform.position.x, 
												transform.position.y - collision.transform.position.y );

			forceToBall.Normalize();	// normalize created vector
			GetComponent<Rigidbody2D>().AddForce( forceToBall * kickForce, ForceMode2D.Impulse );	// add the vector times our kicking force as an impulse to the ball
		}
	}

	/// <summary>
	/// Resets the position and velocity of the ball to its starting point. Resets players to their spawning points as well.
	/// </summary>
	void ResetGameField()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;	// stop ball from moving
		transform.position = BallSpawner.transform.position;	// set ball back in center

		// move players to starting positions
		player1.transform.position = player1Spawn.transform.position;
		player2.transform.position = player2Spawn.transform.position;
	}
}
