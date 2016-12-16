/*********
 *		Author:  James Keeling
 *		Purpose: Provide the basic framework for the cocaine pickup drug effect. This doubles the characters speed. Collecting more consecutively will keep multiplying speed.
 ********/


using UnityEngine;
using System.Collections;

public class Cocaine : MonoBehaviour, IDrugAffectable
{
	public float highDuration;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DrugEffectStart(Player p)
	{
		p.speed *= 2;   // increase speed of player while high
		StartCoroutine(DrugActive(p));  // run for the duration then reset
	}

	public void DrugEffectOver(Player p)
	{
		p.speed *= 0.5f;    // reset speed to normal
	}

	public IEnumerator DrugActive(Player p)
	{
		float startTime = Time.time;
		while (Time.time < startTime + highDuration)
			yield return null;

		DrugEffectOver(p);  // remove high effects
		Destroy(gameObject);    // destroy the pickup object
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "player")
		{
			Player p = collision.gameObject.GetComponent<Player>();
			DrugEffectStart(p); // start drugs effects
			StartCoroutine(DrugActive(p));  // run until drug exit condition

			// remove sprite and trigger
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<CircleCollider2D>().enabled = false;
		}
	}
}
