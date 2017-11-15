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
    public Text countText;
    public Text doorText;

    private int numberofstars;
    private bool exitOpen;
    private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
        numberofstars = GameObject.FindGameObjectsWithTag("Star").Length;
        gameOver = false;
        exitOpen = false;
        gameOverText.text = "";
        scoreText.text = "";
		score = 0;
        doorText.text = "The door is shut";
        updateText();
        UpdateScore ();
	}

    void Update()
    {
        UpdateScore();
        updateText();
     

        if (!gameOver) { 
        if (GameObject.FindGameObjectsWithTag("Player").Length < 1) GameOver();
            }
		if (gameOver)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				//Unity 5 og fremefter benytter ikke LoadLevel længere, SceneManager benyttes i stedet.
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

    public bool DoorOpen()
    {
        return exitOpen;
    }

    void updateText()
    {
        int count = countStarts();
        countText.text = "Stars left: " + count;
        if (numberofstars > count && !exitOpen)
        {
            exitOpen = true;
            doorText.text = "The door is open";
        }
    }

    int countStarts()
    {
        return GameObject.FindGameObjectsWithTag("Star").Length;
    }

    public void levelComplete()
    {

        gameOverText.text = "TEST du er nået i mål";
        //vis mål tekst evt. gør point op (til total point)
        //fade til ny bane eller level select

        //Lige nu vil der kun blive skiftet til level 2 uanset hvilke bane man gør færdig.
        //Liste af scener, (switch case til skift af scene alt afhængig af hvilke bane?) så der skiftes korrekt.
        SceneManager.LoadScene("Level002");
    }
}

