using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int gameOverScore;
    private int player1Score = 0;
    private int player2Score = 0;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    public void Player1Scored()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        CheckGameOver();
    }
    public void Player2Scored()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (player1Score == gameOverScore || player2Score == gameOverScore)
        {
            SceneManager.LoadScene(2);
        }
    }
}

