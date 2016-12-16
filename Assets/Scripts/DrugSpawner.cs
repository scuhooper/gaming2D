using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugSpawner : MonoBehaviour {
	public GameObject[] drugList;

	GameObject spawnedDrug;
	bool bIsRunning;
	// Use this for initialization
	void Start () {
		bIsRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!bIsRunning )
			StartCoroutine( SpawnDrugs() );
	}

	IEnumerator SpawnDrugs()
	{
		bIsRunning = true;
		while ( spawnedDrug )
		{
			yield return null;
		}

		yield return new WaitForSeconds( Random.Range( 5, 10 ) );
		spawnedDrug = Instantiate( drugList[ Random.Range( 0, drugList.Length ) ], transform.position, transform.rotation );
		bIsRunning = false;
	}
}
