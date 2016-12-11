using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class God : MonoBehaviour
{

	public Text leftScore;
	public Text rightScore;
	public GameObject LeftScoreBox;
	public GameObject RightScoreBox;
	public GameObject Ball;
	public Transform BallSpawner;
	int rightNum;
	int leftNum;


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		rightScore.text = "" + rightNum;
		leftScore.text = "" + leftNum;

	}

	public void AddScoreLeft(int points)
	{
		leftNum++;
		leftScore.text = "" + leftNum;

	}
	public void AddScoreRight(int points)
	{
		rightNum++;
		rightScore.text = "" + rightNum;

	}

	public void OnFire()
	{
		if (rightNum >= 5)
		{
			//Ball gameScript = NewMethod();
			Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));

		}
		if (leftNum >= 5)
		{
			//Ball gameScript = NewMethod();
			Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
		}
	}

	public void OnTriggerEnter2D(Collider2D Ball)
	{
		if (Ball.gameObject.tag == "LeftGoal")
		{
			rightNum++;
			Destroy(Ball);
			Debug.Log("Score");
			Instantiate(Ball, BallSpawner.position, BallSpawner.rotation);
		}
		if (Ball.gameObject.tag == "RightGoal")
		{
			leftNum++;
			Destroy(Ball);
			Debug.Log("Score");
			Instantiate(Ball, BallSpawner.position, BallSpawner.rotation);
		}

	}
	private static Ball NewMethod()
	{
		return FindObjectOfType<Ball>();
	}


}
