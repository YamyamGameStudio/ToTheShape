using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Alican
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [SerializeField] private TextMeshProUGUI scoreText, highScoreText, hpText;

        public void ChangeScoreText(int score)
        {
            scoreText.text = ""+score;
        }
        public void ChangeHighScoreText(int highScore)
        {
            highScoreText.text = ""+highScore;
        }
        public void ChangeHPText(int hp)
        {
            hpText.text = ""+hp;
        }
    }
}