using UnityEngine;
using System.Collections;

public class joint : MonoBehaviour
{

	public void OnTrigger2DEnter(Collision2D col)
	{

		if (col.gameObject.name == "player")
		{
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}

}
