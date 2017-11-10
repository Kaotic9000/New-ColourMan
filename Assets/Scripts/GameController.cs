using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	//public prefab prefab;

	public Text scoreText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
//		restart = false;
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
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void SpawnWaves ()
	//IEnumerator
	{

		
			//Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
			//Instantiate (prefab, spawnPosition, Quaternion.identity);
			//if (gameOver)
			//{
			//	restartText.text = "Press 'R' for Restart";
		    //	restart = true;
			
	//	}
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
