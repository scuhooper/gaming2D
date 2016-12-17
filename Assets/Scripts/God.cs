using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class God : MonoBehaviour
{
    public GameObject pauseMenu;
	public Text leftScore;
	public Text rightScore;
	public GameObject retryMenu;
	public Canvas cardboard;
	public Text winnerText;
	public float roundDuration;
	public int maxGoals;
	timerScript timer;
	int rightNum;
	int leftNum;

	bool bIsGameWon;

	// Use this for initialization
	void Start()
	{
		leftNum = 0;
		rightNum = 0;
		leftScore.text = leftNum.ToString();
		rightScore.text = rightNum.ToString();
		timer = FindObjectOfType<timerScript>();
		bIsGameWon = false;
	}

	// Update is called once per frame
	void Update()
	{
		if ( bIsGameWon )
			RetryScreen();

		if ( timer.time > roundDuration )
		{
			if ( leftNum > rightNum )
				winnerText.text = "Player 1 Wins!";
			else if ( rightNum > leftNum )
				winnerText.text = "Player 2 Wins!";
			else
				winnerText.text = "Draw!";

			RetryScreen();
		}
	}

	public void AddScoreLeft()
	{
		leftNum++;
		leftScore.text = leftNum.ToString();
		if ( leftNum == maxGoals )
		{
			winnerText.text = "Player 1 Wins!";
			bIsGameWon = true;
		}
	}
	public void AddScoreRight()
	{
		rightNum++;
		rightScore.text = rightNum.ToString();
		if ( rightNum == maxGoals )
		{
			winnerText.text = "Player 2 Wins!";
			bIsGameWon = true;
		}
	}

	void RetryScreen()
	{
		Time.timeScale = 0;
		foreach ( Player p in FindObjectsOfType<Player>() )
		{
			p.enabled = false;
		}
		cardboard.enabled = true;
		retryMenu.SetActive( true );
        pauseMenu.SetActive(false);
	}

	public void OnRetryButtonClick()
	{
		SceneManager.LoadScene( "Scene1" );
	}
}
