using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text HighScoreText;


    float pointsPerSecond = 1;
    float Score = 0;
    float HighScore;

    public static ScoreManager ins;

    void Awake()
    {
        ins = this;
    }
    
    void Start()
    {
        
        scoreText.text = "Points:" + Mathf.Round(Score);
    }
    void Update()
    {

        scoreText.text = "Points:" + Mathf.RoundToInt(Score);

        if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", Mathf.RoundToInt(Score));
            HighScoreText.text = Score.ToString();
        }

    }

    public void AddPoint()
    {
        Score += pointsPerSecond * Time.deltaTime;
    }
}
