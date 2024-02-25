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

        private Slider _currentSkillBar;
        private float _currentSkillTimer;
        private bool _isSkillShowed;

        private bool _isPaused = false;

        private void Awake()
        {
            Subscribe();
        }

        private void Update()
        {
            if (_isSkillShowed)
            {
                _currentSkillTimer -= Time.deltaTime;
                if (_currentSkillTimer  >= 0)
                {
                    UpdateSkillBar(_currentSkillBar, _currentSkillTimer);
                }
                else
                {
                    _magnetBar.gameObject.SetActive(false);
                    _shieldBar.gameObject.SetActive(false);
                    _nitroBar.gameObject.SetActive(false);
                    _isSkillShowed = false;
                }
            }
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
        public void ShowNitroBar(float timeOfUse)
        {
            _nitroBar.maxValue = timeOfUse;
            _nitroBar.value = timeOfUse;
            _nitroBar.gameObject.SetActive(true);
            _currentSkillBar = _nitroBar;
            _isSkillShowed = true;
            _currentSkillTimer = timeOfUse;
        }
        public void ShowMagnetBar(float timeOfUse)
        {
            _magnetBar.gameObject.SetActive(true);
            _magnetBar.maxValue = timeOfUse;
            _magnetBar.value = timeOfUse;
            _currentSkillBar = _magnetBar;
            _isSkillShowed = true;
            _currentSkillTimer = timeOfUse;
        }
        public void ShowShieldBar(float timeOfUse)
        {
            _shieldBar.gameObject.SetActive(true);
            _shieldBar.value = timeOfUse;
            _shieldBar.maxValue = timeOfUse;
            _currentSkillBar = _shieldBar;
            _isSkillShowed = true;
            _currentSkillTimer = timeOfUse;
        }

        private void UpdateSkillBar(Slider bar, float value)
        {
            bar.value = value;
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
            PauseSwap();
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
