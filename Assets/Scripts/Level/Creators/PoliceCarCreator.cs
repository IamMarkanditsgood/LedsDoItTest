using System;
using System.Collections.Generic;
using Entities.Cathcable;
using Entities.Cathcable.BasicClasses;
using Entities.Cathcable.PoliceCar;
using Level.InitScriptableObjects.Catchable;
using Level.SceneManagers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Creators
{
    [Serializable]
    public class PoliceCarCreator : BasicCatchableCreator
    {
        [SerializeField] private List<Transform> _policeSpawnPosition;
        
        public override void CreateObstacle()
        {
            GameObject policeCar = CreatePoliceCar();
            SetRandPosition(policeCar);
            InitPoliceCar(policeCar);
        }

        private GameObject CreatePoliceCar()
        {
            GameObject policeCar = LevelData.instance.PoliceCar.GetComponent();
            policeCar.AddComponent<PoliceCar>();
            policeCar.SetActive(true);
            return policeCar;
        }

        private void SetRandPosition(GameObject policeCar)
        {
            int randomIndex = Random.Range(0, _policeSpawnPosition.Count);
            Transform randomSpawnPosition = _policeSpawnPosition[randomIndex];
            policeCar.transform.position = randomSpawnPosition.position;
        }

        private void InitPoliceCar(GameObject policeCar)
        {
            ObstacleConfig obstacleConfig = GetConfig(ObstacleTypes.PoliceCar);
            Catchable script =  policeCar.GetComponent<Catchable>();
            script.Init(obstacleConfig);  
        }
    }
}