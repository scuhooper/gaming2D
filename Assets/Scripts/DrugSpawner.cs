using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugSpawner : MonoBehaviour {
	public GameObject[] drugList;	// holds a list of drugs in the game to spawn. Editable inside editor

	GameObject spawnedDrug;	// holds to make sure a drug is spawned
	bool bIsRunning;    // is our coroutine currently running
	static System.Random rand = new System.Random();

	// Use this for initialization
	void Start () {
		bIsRunning = false;	// set variable to initially be false
	}
	
	// Update is called once per frame
	void Update () {
		if(!bIsRunning )	// if coroutine isn't running - this means it has fully finished
			StartCoroutine( SpawnDrugs() );	// start it
	}

	/// <summary>
	/// Coroutine spawns a drug if one is not currently present, it also waits a random amount after the drug is picked up before creating a new one
	/// </summary>
	/// <returns></returns>
	IEnumerator SpawnDrugs()
	{
		bIsRunning = true;	// set coroutine running to true
		while ( spawnedDrug )	// just return if the drug still exists
		{
			yield return null;
		}

		yield return new WaitForSeconds( rand.Next( 5, 10 ) );	// wait a random amount of time before preceding. acts like a spawn delay
		spawnedDrug = Instantiate( drugList[ rand.Next( 0, drugList.Length ) ], transform.position, transform.rotation );	// make a new drug pickup and store its object
		bIsRunning = false;	// coroutine is stopping
	}
}
