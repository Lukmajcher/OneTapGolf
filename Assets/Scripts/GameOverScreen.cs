using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public int highScore;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highScoreText.text = "BEST: " + highScore.ToString();
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
