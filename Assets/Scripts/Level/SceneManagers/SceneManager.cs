using System;
using System.Collections.Generic;
using Entities.Cathcable;
using Entities.Cathcable.Bad;
using Entities.Cathcable.BasicClasses;
using Entities.Cathcable.Good;
using Entities.Cathcable.PoliceCar;
using Entities.Character.Skills;
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
            if (_scoreTimer >= _scoreTimeAdd)
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
            policeCar.AddComponent<PoliceCar>();
            policeCar.SetActive(true);
            int randomIndex = Random.Range(0, _policeSpawnPosition.Count);
            Transform randomSpawnPosition = _policeSpawnPosition[randomIndex];
            policeCar.transform.position = randomSpawnPosition.position;
            ObstacleConfig obstacleConfig = GetConfig(ObstacleTypes.PoliceCar);
            
            Catchable script =  policeCar.GetComponent<Catchable>();
            script.Init(obstacleConfig);
        }
        
        private ObstacleConfig GetConfig(ObstacleTypes type)
        {
            ObstacleConfig obstacleConfig = _levelData.ObstacleConfigList.ObstacleConfigs[type];
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
                    obstacle.tag = "RoadDefect";
                    obstacle.AddComponent<Crack>();
                    obstacleConfig = GetConfig(ObstacleTypes.Crack);
                    break;
                case ObstacleTypes.OilPuddle:
                    obstacle.tag = "RoadDefect";
                    obstacle.AddComponent<OilPuddle>();
                    obstacleConfig = GetConfig(ObstacleTypes.OilPuddle);
                    break;
                case ObstacleTypes.Coins:
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Coins>();
                    obstacleConfig = GetConfig(ObstacleTypes.Coins);
                    break;
                case ObstacleTypes.Heart:
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Heart>();
                    obstacleConfig = GetConfig(ObstacleTypes.Heart);
                    break;
                case ObstacleTypes.Magnet:
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Magnet>();
                    obstacleConfig = GetConfig(ObstacleTypes.Magnet);
                    break;
                case ObstacleTypes.Nitro:
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Nitro>();
                    obstacleConfig = GetConfig(ObstacleTypes.Nitro);
                    break;
                case ObstacleTypes.Shield:
                    obstacle.AddComponent<Shield>();
                    obstacleConfig = GetConfig(ObstacleTypes.Shield);
                    break;
                default:
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Block>();
                    obstacleConfig = GetConfig(ObstacleTypes.Block);
                    break;
            }
            obstacle.GetComponent<Catchable>().Init(obstacleConfig);
        }
    }
    
}
