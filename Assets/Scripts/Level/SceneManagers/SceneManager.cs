using System;
using Level.Creators;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Level.SceneManagers
{
    [Serializable]
    public class SceneManager
    {
        [SerializeField] private ObstacleCreator _obstacleCreator;
        [SerializeField] private PoliceCarCreator _policeCarCreator;
        
        private LevelData _levelData;
        
        private float _scoreTimer;
        private float _scoreTimeAdd;
        private float _obstacleSpawnTimer;
        private float _obstacleSpawnInterval = 15f;
        private float _policeSpawnTimer;
        private float _policeSpawnInterval = 60f;

        public void Init(LevelConfig levelConfig, LevelData levelData)
        {
            _levelData = levelData;
            _scoreTimeAdd = levelConfig.ScoreTimerAdd;
            _obstacleSpawnInterval = levelConfig.ObstacleSpawnInterval;
            _policeSpawnInterval = levelConfig.PoliceSpawnInterval;
        }

        public void PlayGame()
        {
            UpdateTimers();
            CheckTimers();
        }
        public void UpdateTimers()
        {
            _scoreTimer += Time.deltaTime;
            _obstacleSpawnTimer += Time.deltaTime;
            _policeSpawnTimer += Time.deltaTime;
        }
        
        private void CheckTimers()
        {
            if (_scoreTimer >= _scoreTimeAdd)
            {
                IncreaseGameScore();
                IncreaseGameDifficulty();
                _scoreTimer = 0f;
            }
            if (_obstacleSpawnTimer >= _obstacleSpawnInterval)
            {
                _obstacleCreator.CreateObstacle();
                _obstacleSpawnTimer = 0f;
            }
            if (_policeSpawnTimer >= _policeSpawnInterval)
            {
                _policeCarCreator.CreateObstacle();
                _policeSpawnTimer = 0f;
            }
            
        }
        
        private void IncreaseGameDifficulty()
        {
            _levelData.GlobalSpeed += 0.1f;
        }
        
        private void IncreaseGameScore()
        {
            _levelData.GameScore++;
        }
    }
}
