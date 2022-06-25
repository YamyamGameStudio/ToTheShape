using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Alican
{
    public class UITextManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText, hightScoreText, lifeText;
        private float score = 0f;

        private void Update()
        {
            Score();
        }

        private void Score()
        {
            score += Time.deltaTime;
            scoreText.text = ""+(int)score;
        }
    }
}