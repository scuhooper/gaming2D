/*********
 *		Author:  James Keeling
 *		Purpose: Class for PCP effect. This makes the player appear larger, take half damage, and deal double damage.
 ********/
 
using UnityEngine;
using System.Collections;
using System;

public class PCP : MonoBehaviour, IDrugAffectable {
	public float highDuration;	// duration for the drug effect

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DrugEffectStart( Player p )
	{
		p.transform.localScale *= 2;	// increase player size
		p.armor *= 0.5f;	// give character 50% armor
		p.damage *= 2;	// player deals double damage
	}

	public void DrugEffectOver( Player p )
	{
		p.transform.localScale *= 0.5f;	// scale player down by half
		p.armor *= 2;	// character armor is gone.
		p.damage /= 2;	// character damage is halved
	}

	public IEnumerator DrugActive( Player p )
	{
		float startTime = Time.time;	// get current time
		while ( Time.time < startTime + highDuration )	// stall function until the duration has passed
			yield return null;

		DrugEffectOver( p );    // call function to undo drug effects
		Destroy( gameObject );
	}

	private void OnTriggerEnter2D( Collider2D collision )
	{
		// player picks up drug
		if ( collision.gameObject.tag == "player" )
		{
			Player p = collision.gameObject.GetComponent<Player>();
			DrugEffectStart( p );	// start the drug effects
			StartCoroutine( DrugActive( p ) );  // run the effects until exit condition

			// remove sprite and trigger
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
		}
	}
}
