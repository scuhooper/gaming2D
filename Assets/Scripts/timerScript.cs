using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
	public Text timerLabel;
	float time;

	void Update()
	{
		time += Time.deltaTime;
		var minutes = time / 60;
		var seconds = time % 60;
		timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
	}
}