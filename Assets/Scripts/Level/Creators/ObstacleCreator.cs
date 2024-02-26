using System;
using System.Collections.Generic;
using Entities.Cathcable;
using Entities.Cathcable.Bad;
using Entities.Cathcable.BasicClasses;
using Entities.Cathcable.Good;
using Level.InitScriptableObjects.Catchable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Creators
{
    [Serializable]
    public class ObstacleCreator : BasicCatchableCreator
    {
        [SerializeField] private List<Transform> _obstaclesSpawnPosition;
        
        public override void CreateObstacle()
        {
            GameObject obctacle = SetObstacle();
            SetRandPosition(obctacle);
        }

        private GameObject SetObstacle()
        {
            GameObject obctacle = LevelData.instance.Obstacles.GetComponent();
            obctacle.SetActive(true);
            ObstacleTypes obstacleTypes =  GetRandomEnumValue<ObstacleTypes>();
            SetRandomObstacleScript(obstacleTypes, obctacle);
            return obctacle;
        }

        private void SetRandPosition(GameObject obctacle)
        {
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
        
        private void SetRandomObstacleScript(ObstacleTypes obstacleType, GameObject obstacle)
        {
            ObstacleConfig obstacleConfig = GetObstacleConfig(obstacleType, obstacle);
            obstacle.GetComponent<Catchable>().Init(obstacleConfig);
        }

        private ObstacleConfig GetObstacleConfig(ObstacleTypes obstacleType, GameObject obstacle)
        {
            ObstacleConfig obstacleConfig;
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
                    obstacle.tag = "Coin";
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
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Shield>();
                    obstacleConfig = GetConfig(ObstacleTypes.Shield);
                    break;
                default:
                    obstacle.tag = "Untagged";
                    obstacle.AddComponent<Block>();
                    obstacleConfig = GetConfig(ObstacleTypes.Block);
                    break;
            }

            return obstacleConfig;
        }
    }
}