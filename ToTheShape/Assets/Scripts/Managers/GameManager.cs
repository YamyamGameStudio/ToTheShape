using System;
using System.Collections;
using System.Collections.Generic;
using Alican;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private int score;
    [SerializeField] private int hp=3;
    [SerializeField] private int highScore;
    private const string HighScoreKey = "highScore";


    private int playerChangeCounter;

    private float timeScaleValue = 1f;

    private void Start()
    {
        Time.timeScale = 1f;
        UIManager.Instance.ChangeScoreText(score);
        UIManager.Instance.ChangeHPText(hp);

        //high score tanımlama
        if (!PlayerPrefs.HasKey(HighScoreKey))
        {
            PlayerPrefs.SetInt(HighScoreKey,0);
        }
        highScore = PlayerPrefs.GetInt(HighScoreKey);
        UIManager.Instance.ChangeHighScoreText(highScore);
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UIManager.Instance.ChangeScoreText(score);
        
        //high score kontrol
        if (score>=highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey,highScore);
            UIManager.Instance.ChangeHighScoreText(highScore);
        }
    }

    public void DecreaseHP()
    {
        hp--;
        if (hp<=0)
        {
            //level finish
            FinishGame();
        }
        else
        {
            UIManager.Instance.ChangeHPText(hp);
        }
    }

    private void FinishGame()
    {
        UIManager.Instance.TryButtonActive();
        Time.timeScale = 0f;
    }

    

    public void IncreasePlayerChangeCount()
    {
        playerChangeCounter++;
        if (playerChangeCounter==1)
        {
            ChangePlayer();
            playerChangeCounter = 0;
            timeScaleValue += 0.05f;
            Time.timeScale = timeScaleValue;
        }
    }
    
    public void ChangePlayer()
    {
        PlayerSpawner.Instance.SpawnPlayer();
    }
}
