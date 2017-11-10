using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;

	public Text scoreText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
		gameOverText.text = "";
        scoreText.text = "";
		score = 0;
		UpdateScore ();
	}

    void Update()
    {
        score = 0;
        UpdateScore();

        if (!gameOver) { 
        if (GameObject.FindGameObjectsWithTag("Player").Length < 1) GameOver();
            }
		if (gameOver)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				//Unity 5 og fremefter benytter ikke LoadLevel længere SceneManager benyttes i stedet.
                //Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "     Game Over!\n\n Press 'R' for Restart";
		gameOver = true;
	}
}
