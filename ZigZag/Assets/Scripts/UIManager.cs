using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager instance;


    public GameObject zigZagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject inGameScoreObject;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text inGameScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();

    }

    public void GameStart()
    {
        tapText.GetComponent<Animator>().Play("textFallDown");
        zigZagPanel.GetComponent<Animator>().Play("panelUp");
        inGameScoreObject.SetActive(true);
    }
    private void Update()
    {
        inGameScore.text ="Score:" + " "+ ScoreManager.instance.inGameScoring;

    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("level1");
    }
}
