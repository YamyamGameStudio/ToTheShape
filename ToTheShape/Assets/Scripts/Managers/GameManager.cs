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
        if (hp<0)
        {
            //level finish
        }
        else
        {
            UIManager.Instance.ChangeHPText(hp);
        }
    }
}
