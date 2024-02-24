using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UILevelManager : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;
        [SerializeField] private Slider _magnetBar;
        [SerializeField] private Slider _nitroBar;
        [SerializeField] private Slider _shieldBar;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _startCount;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _gameOverMenu;
        [SerializeField] private GameObject _pauseMenu;

        [SerializeField] private UIPauseMenu _uiPauseManager;
        [SerializeField] private UIGameOverMenu _uiGameOverManager;

        private bool _isPaused = false;

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
            _pauseButton.onClick.AddListener(PauseSwap);
            _uiPauseManager.OnExitButton += Exit;
            _uiPauseManager.OnRestartButton += Restart;
            _uiPauseManager.OnCloseButton += ClosePauseManager;
            _uiGameOverManager.OnExitButton += Exit;
            _uiGameOverManager.OnRestartButton += Restart;
        }
        
        private void Unsubscribe()
        {
            _pauseButton.onClick.RemoveListener(PauseSwap);
            _uiPauseManager.OnExitButton -= Exit;
            _uiPauseManager.OnRestartButton -= Restart;
            _uiPauseManager.OnCloseButton -= ClosePauseManager;
            _uiGameOverManager.OnExitButton -= Exit;
            _uiGameOverManager.OnRestartButton -= Restart;
        }
        public void UpdateHealthBar(float healthValue)
        {
            
            healthValue = Mathf.Clamp01(healthValue);
            _healthBar.value = healthValue;
        }
        public void UpdateNitroBar(float nitroValue)
        {
            nitroValue = Mathf.Clamp01(nitroValue);
            _nitroBar.value = nitroValue;
        }
        public void UpdateMagnetBar(float magnetValue)
        {
            magnetValue = Mathf.Clamp01(magnetValue);
            _magnetBar.value = magnetValue;
        }
        public void UpdateShieldBar(float shieldValue)
        {
            shieldValue = Mathf.Clamp01(shieldValue);
            _shieldBar.value = shieldValue;
        }
        public void GameOver(int score, int bestScore)
        {
            _gameOverMenu.SetActive(true);
            _uiGameOverManager.SetScores(bestScore,score);
        }
        public void SetScoreText(int score)
        {
            _scoreText.text = "Score: " + score.ToString();
        }

        public void SetStartCount(string count)
        {
            _startCount.text = count;
        }

        private void PauseSwap()
        {
            Time.timeScale = _isPaused ? 1 : 0;
            _pauseMenu.SetActive(!_isPaused);
            _isPaused = !_isPaused;
        }
        private void ClosePauseManager()
        {
            _pauseMenu.SetActive(false);
        }
        private void Restart()
        {
            Time.timeScale = 1;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        private void Exit()
        {
            Application.Quit();
        }
        
    }
}
