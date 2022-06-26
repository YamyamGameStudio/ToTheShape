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
        [SerializeField] private GameObject failText,wrongSideText;

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

        public void FailTextActive()
        {
            failText.SetActive(true);
        }

        public void ShowWrongSideText()
        {
            wrongSideText.SetActive(true);
            Invoke(nameof(CloseWrongSideText),1.5f);
        }

        private void CloseWrongSideText()
        {
            wrongSideText.SetActive(false);
        }
    }
}