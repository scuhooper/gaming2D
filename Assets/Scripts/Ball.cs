using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public int pointValue = 1;
	public GameObject BallSprite;
	public Transform BallSpawner;
	public GameObject Goal;
	public Color lerpedColor;


	void Start()
	{
		Goal.SetActive(false);
	}


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
			lerpedColor = GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(Color.green, Color.red, Mathf.PingPong(Time.time, 1));
			transform.parent = BallSpawner;
			//Goal.SetActive(true);

		}
		else
		{
			Goal.SetActive(false);
		}
		if (col.gameObject.name == "RightGoal")
		{
			God gameScript = NewMethod();
			gameScript.AddScoreRight(pointValue);
			transform.position = Vector3.Lerp(transform.position, BallSpawner.position, 1);
			lerpedColor = GetComponent<SpriteRenderer>().color = Color.LerpUnclamped(Color.green, Color.red, Mathf.PingPong(Time.time, 1));
			transform.parent = BallSpawner;
			//Goal.SetActive(true);

		}
		else {
			//Goal.SetActive(false);
		}


	}

	private static God NewMethod()
	{
		return FindObjectOfType<God>();
	}
}
