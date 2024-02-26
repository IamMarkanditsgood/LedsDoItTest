using System;
using TMPro;
using UI.UIPanels;
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
        private bool _isPaused;

        private void Awake()
        {
            Subscribe();
        }

        private void Update()
        {
            IsSkillShowed();
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
            _healthBar.value = healthValue;
        }
        
        public void ShowNitroBar(float timeOfUse)
        {
            _nitroBar.maxValue = timeOfUse;
            _nitroBar.value = timeOfUse;
            _currentSkillTimer = timeOfUse;
            _currentSkillBar = _nitroBar;
            _nitroBar.gameObject.SetActive(true);
            _isSkillShowed = true;
        }
        
        public void ShowMagnetBar(float timeOfUse)
        {
            _magnetBar.gameObject.SetActive(true);
            _magnetBar.maxValue = timeOfUse;
            _magnetBar.value = timeOfUse;
            _currentSkillTimer = timeOfUse;
            _currentSkillBar = _magnetBar;
            _isSkillShowed = true;
            
        }
        
        public void ShowShieldBar(float timeOfUse)
        {
            _shieldBar.gameObject.SetActive(true);
            _shieldBar.value = timeOfUse;
            _shieldBar.maxValue = timeOfUse;
            _currentSkillTimer = timeOfUse;
            _currentSkillBar = _shieldBar;
            _isSkillShowed = true;
        }

        public void GameOver(int score, int bestScore)
        {
            _gameOverMenu.SetActive(true);
            _uiGameOverManager.SetScores(bestScore,score);
        }
        
        public void SetScoreText(int score)
        {
            _scoreText.text = "Score: " + score;
        }

        public void SetStartCount(string count)
        {
            _startCount.text = count;
        }

        public void OffStartCount()
        {
            _startCount.enabled = false;
        }

        private void IsSkillShowed()
        {
            if (_isSkillShowed)
            {
                ShowSkill();
            }
        }

        private void ShowSkill()
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
        
        private void UpdateSkillBar(Slider bar, float value)
        {
            bar.value = value;
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
