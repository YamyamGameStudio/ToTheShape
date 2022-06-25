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


    private int playerChangeCounter;

    private float timeScaleValue = 1f;

    private void Start()
    {
        UIManager.Instance.ChangeScoreText(score);
        UIManager.Instance.ChangeHPText(hp);
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UIManager.Instance.ChangeScoreText(score);
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
