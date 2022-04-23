using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameOver_canvas;
    [SerializeField] GameObject score_canvas;
    [SerializeField] GameObject confirm_canvas;

    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        gameOver_canvas.SetActive(false);
        confirm_canvas.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        currentScore += score;
        GetComponent<ScoreController>().UpdateScore(currentScore);
    }

    public void GameOver()
    {
        gameOver_canvas.SetActive(true);
        PlayerPrefs.SetInt("highscore", currentScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Confirm()
    {
        confirm_canvas.SetActive(true);
    }

    public void BackToMenu(bool isBack)
    {
        if(isBack)
            SceneManager.LoadScene("MainMenu");
        else
            confirm_canvas.SetActive(false);
    }
}
