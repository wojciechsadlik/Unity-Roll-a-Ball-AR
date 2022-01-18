using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABallAR
{
    public class GameLogic : MonoBehaviour
    {
        private int m_Score;

        [SerializeField]
        private RandomSpawn pickupSpawner;
        public RandomBomb bombSpawner;

        [SerializeField]
        private Text m_ScoreText;

        public void StartGame()
        {
            SetScore(0);

            pickupSpawner.Spawn();
        }

        public void AddScore()
        {
            SetScore(m_Score + 1);
        }
        public void DeleteScore()
        {
            SetScore(0);
        }

        private void SetScore(int score)
        {
            m_Score = score;
            m_ScoreText.text = "Points: " + m_Score;
        }
    }
}

