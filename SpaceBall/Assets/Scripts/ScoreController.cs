using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextInGP, scoreTextInGO;
    [SerializeField] TextMeshProUGUI highscoreTextInGP, highscoreTextInGO;

    private void Start()
    {
        highscoreTextInGP.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void UpdateScore(int score)
    {
        scoreTextInGP.text = "" + score;
        highscoreTextInGP.text = "" + score;

        if(score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreTextInGP.text = PlayerPrefs.GetInt("highscore").ToString();
        }
        //scoreTextInGO.text = "" + currentScore;
    }
}
