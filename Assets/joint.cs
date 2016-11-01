using UnityEngine;
using System.Collections;

public class joint : MonoBehaviour
{
	//public GameObject jointGO;

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "player" || col.gameObject.name == "joint(Clone)")
		{
			GetComponent<SpriteRenderer>().enabled = false;
		}

	}
}