using System;
using System.Collections.Generic;
using Entities.Character.Skills;
using Entities.Skills;
using Entities.Skills.Bad;
using Entities.Skills.Good;
using Level.InitScriptableObjects;
using Level.InitScriptableObjects.Catchable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    [Serializable]
    public class SceneManager
    {
        [SerializeField] private List<Transform> _obstaclesSpawnPosition;
        [SerializeField] private List<Transform> _policeSpawnPosition;
        [SerializeField] private ObstacleConfigList _obstacleConfigList;
        private LevelData _levelData;
        private float _scoreTimer;
        private float _obstacleSpawnTimer;
        private float _obstacleSpawnInterval = 15f;
        private float _policeSpawnTimer;
        private float _policeSpawnInterval = 60f;

        public void Init(LevelConfig levelConfig, LevelData levelData)
        {
            _levelData = levelData;
            _scoreTimer = levelConfig.ScoreTimer;
            _obstacleSpawnTimer = levelConfig.ObstacleSpawnTimer;
            _obstacleSpawnInterval = levelConfig.ObstacleSpawnInterval;
            _policeSpawnTimer = levelConfig.PoliceSpawnTimer;
            _policeSpawnInterval = levelConfig.PoliceSpawnInterval;
        }

        public void PlayGame()
        {
            UpdateTimers();
        }
        public void UpdateTimers()
        {
            _scoreTimer += Time.deltaTime;
            _obstacleSpawnTimer += Time.deltaTime;
            _policeSpawnTimer += Time.deltaTime;
            CheckTimers();
        }
        
        private void CheckTimers()
        {
            if (_scoreTimer >= 1f)
            {
                IncreaseGameScore();
                IncreaseGameDifficulty();
                _scoreTimer = 0f;
            }
            if (_obstacleSpawnTimer >= _obstacleSpawnInterval)
            {
               CreateRandomObstacle();
                _obstacleSpawnTimer = 0f;
            }
            if (_policeSpawnTimer >= _policeSpawnInterval)
            {
                CreatePoliceCar();
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
        public void CreateRandomObstacle()
        {
            GameObject obctacle = _levelData.Obstacles.GetComponent();
            obctacle.SetActive(true);
            ObstacleTypes obstacleTypes =  GetRandomEnumValue<ObstacleTypes>();
            SetRandomObstacleScript(obstacleTypes, obctacle);
            int randomIndex = Random.Range(0, _obstaclesSpawnPosition.Count);
            Transform randomSpawnPosition = _obstaclesSpawnPosition[randomIndex];
            obctacle.transform.position = randomSpawnPosition.position;
            
        }
        private static T GetRandomEnumValue<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            int randomIndex = Random.Range(0, values.Length);
            return (T)values.GetValue(randomIndex);
        }
        public void CreatePoliceCar()
        {
            GameObject policeCar = _levelData.PoliceCar.GetComponent();
            policeCar.SetActive(true);
            int randomIndex = Random.Range(0, _policeSpawnPosition.Count);
            Transform randomSpawnPosition = _policeSpawnPosition[randomIndex];
            policeCar.transform.position = randomSpawnPosition.position;
            ObstacleConfig obstacleConfig = GetConfig(ObstacleTypes.PoliceCar);
            policeCar.GetComponent<Catchable>().Init(obstacleConfig);
        }
        
        private ObstacleConfig GetConfig(ObstacleTypes type)
        {
            ObstacleConfig obstacleConfig = _obstacleConfigList.ObstacleConfigs[type];
            return obstacleConfig;
        }
        
        private void SetRandomObstacleScript(ObstacleTypes obstacleType, GameObject obstacle)
        {
            ObstacleConfig obstacleConfig = null;
            switch (obstacleType)
            {
                case ObstacleTypes.Block:
                    obstacle.AddComponent<Block>();
                    obstacle.tag = "Killer";
                    obstacleConfig = GetConfig(ObstacleTypes.Block);
                    break;
                case ObstacleTypes.Crack:
                    obstacle.AddComponent<Crack>();
                    obstacleConfig = GetConfig(ObstacleTypes.Crack);
                    break;
                case ObstacleTypes.OilPuddle:
                    obstacle.AddComponent<OilPuddle>();
                    obstacleConfig = GetConfig(ObstacleTypes.OilPuddle);
                    break;
                case ObstacleTypes.Coins:
                    obstacle.AddComponent<Coins>();
                    obstacleConfig = GetConfig(ObstacleTypes.Coins);
                    break;
                case ObstacleTypes.Heart:
                    obstacle.AddComponent<Heart>();
                    obstacleConfig = GetConfig(ObstacleTypes.Heart);
                    break;
                case ObstacleTypes.Magnet:
                    obstacle.AddComponent<Magnet>();
                    obstacleConfig = GetConfig(ObstacleTypes.Magnet);
                    break;
                case ObstacleTypes.Nitro:
                    obstacle.AddComponent<Nitro>();
                    obstacleConfig = GetConfig(ObstacleTypes.Nitro);
                    break;
                case ObstacleTypes.Shield:
                    obstacle.AddComponent<Shield>();
                    obstacleConfig = GetConfig(ObstacleTypes.Shield);
                    break;
            }
            obstacle.GetComponent<Catchable>().Init(obstacleConfig);
        }
    }
    
}
