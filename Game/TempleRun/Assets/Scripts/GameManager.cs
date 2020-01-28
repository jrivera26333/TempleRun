using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score = 0;

    public Text scoreText;
    public Text highScoreText;


    public void Awake()
    {
        highScoreText.text = "Best: " + GetHighScore().ToString();
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score); //Set our variable Highscore with the value of score
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore"); //We are setting Highscore to i
        return i;
    }
}
