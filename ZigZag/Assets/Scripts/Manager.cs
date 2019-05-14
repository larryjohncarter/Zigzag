using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static Manager instance;
    public bool gameOver;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }
    public void GameOver()
    {
        if (gameOver)
        {
            UIManager.instance.GameOver();
            ScoreManager.instance.StopScore();
        }
        
    }
}
