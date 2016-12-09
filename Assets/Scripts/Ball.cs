using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
	public int pointValue = 1;
	public GameObject BallSprite;
	public Transform BallSpawner;
	//public GameObject pointConnection;
	// Use this for initialization
	void Start()
	{
		//pointConnection = GetComponent<God>();
	}

	// Update is called once per frame
	void Update()
	{



	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "LeftGoal")
		{
			God gameScript = NewMethod();
			gameScript.AddScoreLeft(pointValue);
			transform.position = Vector3.Lerp(transform.position, BallSpawner.position, 1);
			transform.parent = BallSpawner;

		}
		if (col.gameObject.name == "RightGoal")
		{
			God gameScript = NewMethod();
			gameScript.AddScoreRight(pointValue);
			transform.position = Vector3.Lerp(transform.position, BallSpawner.position, 1);
			transform.parent = BallSpawner;

		}

	}

	private static God NewMethod()
	{
		return FindObjectOfType<God>();
	}
}
