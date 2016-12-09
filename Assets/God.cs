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

		rightScore.text = "Score: " + rightNum;
		leftScore.text = "Score: " + leftNum;

	}

	public void AddScoreLeft(int points)
	{
		leftNum++;
		leftScore.text = "Score: " + leftNum;

	}
	public void AddScoreRight(int points)
	{
		rightNum++;
		rightScore.text = "Score: " + rightNum;

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


}
