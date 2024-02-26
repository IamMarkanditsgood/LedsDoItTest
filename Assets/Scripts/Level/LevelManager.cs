using System.Globalization;
using Entities.Cathcable;
using Entities.Character;
using Level.InitScriptableObjects;
using Level.SceneManagers;
using UI;
using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;

        [SerializeField] private UILevelManager _uiLevelManager;
        [SerializeField] private LevelData _levelData;
        [SerializeField] private SceneManager _sceneManager;
        [SerializeField] private SceneCreator _sceneCreator;
        
        private float _startTimer;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            ManagersInitializing();
            _sceneCreator.AssembleScene();
        }

        private void Update()
        {
            if (!_levelData.IsGameStarted)
            {
                StartOfGame();
                return;
            }
            
            _sceneManager.PlayGame();
            GetCharacterData();
            SetUIAmounts();
            
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Init()
        {
            Time.timeScale = 1;
            _startTimer = _levelConfig.StartTimeEnd;
            Subscribe();
        }
        private void Subscribe()
        {
            _levelData.Character.GetComponent<CharacterManager>().OnDead += EndGame;
            _levelData.Character.GetComponent<CharacterManager>().OnSkillUse += ShowCharacterSkillBar;
        }
        
        private void Unsubscribe()
        {
            
            _levelData.Character.GetComponent<CharacterManager>().OnDead -= EndGame;
            _levelData.Character.GetComponent<CharacterManager>().OnSkillUse -= ShowCharacterSkillBar;
        }

        private void StartOfGame()
        {
            _startTimer -= Time.deltaTime;
            if (_startTimer <= 0)
            {
                _startTimer = 0;
                _levelData.IsGameStarted = true;
                _uiLevelManager.OffStartCount();
            }

            int value = (int) _startTimer + 1 ;
            _uiLevelManager.SetStartCount(value.ToString());
        }
        private void GetCharacterData()
        {
            _levelData.CharacterCoins = _levelData.Character.GetComponent<CharacterManager>().Coins;
            _levelData.CharacterHealth = _levelData.Character.GetComponent<CharacterManager>().Health;
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

        private void ShowCharacterSkillBar(ObstacleTypes obstacleTypes)
        {
            float timeOfUse = _levelData.ObstacleConfigList.ObstacleConfigs[obstacleTypes].TimeOfUse;
            switch (obstacleTypes)
            {
                case ObstacleTypes.Magnet :
                    _uiLevelManager.ShowMagnetBar(timeOfUse);
                    break;
                case  ObstacleTypes.Nitro :
                    _uiLevelManager.ShowNitroBar(timeOfUse);
                    break;
                case ObstacleTypes.Shield :
                    _uiLevelManager.ShowShieldBar(timeOfUse);
                    break;
            }
        }
    }
}
