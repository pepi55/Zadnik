using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour 
{
	private int score;
	private GUIText scoreText;

	void Awake()
	{
		scoreText = GetComponent<GUIText>();
		scoreText.text = "Score: " + score;
	}

	public void IncreaseScore(int incr)
	{
		score += incr;
		scoreText.text = "Score: " + score;
	}
}
