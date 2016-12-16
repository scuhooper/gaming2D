/*********
 *		Author:  James Keeling, Cory Brown
 *		Purpose: Provide the basic framework for the joint pickup drug effect. This resembles bullet time or SlowMo.
 ********/
 
using UnityEngine;
using System.Collections;
using System;

public class joint : MonoBehaviour, IDrugAffectable
{
	public float highDuration;	// drug effect duration

	public void Start()
	{
		
	}

	public void DestroyJoint()
	{
		Destroy(gameObject);
	}

	public void DrugEffectStart( Player p )
	{
		Time.timeScale = 0.5f;  // Produce slow motion effect
		Debug.Log( Time.timeScale );
	}

	public void DrugEffectOver( Player p )
	{
		Time.timeScale = 1;	// resume normal time
	}

	public IEnumerator DrugActive( Player p )
	{
		float startTime = Time.time;
		while ( Time.time < startTime + highDuration )
			yield return null;

		DrugEffectOver( p );	// restore normal status
		DestroyJoint();	// clear joint
	}

	public void OnTriggerEnter2D( Collider2D col )
	{
		if ( col.gameObject.name == "joint(Clone)" )
		{
			DestroyJoint();
		}
		else if ( col.gameObject.tag == "player" )
		{
			Player p = col.gameObject.GetComponent<Player>();
			DrugEffectStart( p );
			StartCoroutine( DrugActive( p ) );

			// remove sprite and trigger
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
		}
	}
}