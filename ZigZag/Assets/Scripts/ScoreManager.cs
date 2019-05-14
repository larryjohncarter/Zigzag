using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;

    public int score = 0;
    public int highScore;
    public int inGameScoring;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void IncrementScore()
    {
        score += 1;
        inGameScoring = score;
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f,0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
  
}
