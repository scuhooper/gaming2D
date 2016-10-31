using UnityEngine;
using System.Collections;

public class jointSpawn : MonoBehaviour
{
	public GameObject go;
	int currentObj = 0;
	int maxObject = 10;
	// Use this for initialization
	void Start()
	{
		StartCoroutine("SpawnJoint");
	}

	// Update is called once per frame
	void Update()
	{


	}

	IEnumerator SpawnJoint()
	{
		if (currentObj < maxObject)
			Instantiate(go, transform);
		currentObj++;
		return (null);
	}
}
