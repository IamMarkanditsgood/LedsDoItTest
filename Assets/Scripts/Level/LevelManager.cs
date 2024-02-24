using System;
using Entities.Character;
using Level.InitScriptableObjects;
using Services.PoolObjectSystem.Pool;
using UI;
using UnityEngine;
using UnityEngine.Pool;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;

        [SerializeField] private UILevelManager _uiLevelManager;
        [SerializeField] private LevelData _levelData;
        [SerializeField] private SceneManager _sceneManager;
        [SerializeField] private SceneCreator _sceneCreator;

        private void Awake()
        {
            Subscribe();
        }

        private void Start()
        {
            ManagersInitializing();
            _sceneCreator.AssembleScene();
        }

        private void Update()
        {
            _sceneManager.PlayGame();
            GetCharacterData();
            SetUIAmounts();
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _levelData.Character.GetComponent<CharacterManager>().OnDead += EndGame;
        }
        
        private void Unsubscribe()
        {
            _levelData.Character.GetComponent<CharacterManager>().OnDead -= EndGame;
        }

        private void GetCharacterData()
        {
            _levelData.CharacterCoins = _levelData.Character.GetComponent<CharacterManager>().GetCoins();
            _levelData.CharacterHealth = _levelData.Character.GetComponent<CharacterManager>().GetHealth();
        }
        private void SetUIAmounts()
        {
            _uiLevelManager.SetScoreText(_levelData.GameScore);
            _uiLevelManager.UpdateHealthBar(_levelData.CharacterHealth);
            
        }
        private void EndGame()
        {
            if (_levelData.BestScore < _levelData.GameScore)
            {
                _levelData.BestScore = _levelData.GameScore;
            }

            _uiLevelManager.GameOver(_levelData.GameScore,_levelData.BestScore);
            Time.timeScale = 0;
        }
        
        private void ManagersInitializing()
        {
            _sceneManager.Init(_levelConfig,_levelData);
            _sceneCreator.Init(_levelConfig,_levelData);
        }

        private void SetNitroBar(float value)
        {
            _uiLevelManager.UpdateNitroBar(value);
        }

        private void SetShieldBar(float value)
        {
            _uiLevelManager.UpdateShieldBar(value);
        }

        private void SetMagnetBar(float value)
        {
            _uiLevelManager.UpdateMagnetBar(value);
        }
    }
}
