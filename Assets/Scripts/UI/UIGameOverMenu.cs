﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIGameOverMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bestScoreText;
        [SerializeField] private TextMeshProUGUI _yourScoreText;
        
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        public event Action OnRestartButton;
        public event Action OnExitButton;
        
        private void Awake()
        {
            Subscribe();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _restartButton.onClick.AddListener(Restart);
            _exitButton.onClick.AddListener(Exit);
        }
        private void Unsubscribe()
        {
            _restartButton.onClick.RemoveListener(Restart);
            _exitButton.onClick.RemoveListener(Exit);
        }

        public void SetScores(int bestScore, int currentScore)
        {
            _bestScoreText.text = "Best Score: " + bestScore.ToString();
            _yourScoreText.text = "Your Score: " + currentScore.ToString();
        }
        public void Restart()
        {
            OnRestartButton?.Invoke();
        }
        public void Exit()
        {
            OnExitButton?.Invoke();
        }
    }
}