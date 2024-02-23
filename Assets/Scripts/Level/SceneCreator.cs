using System;
using System.Collections.Generic;
using Entities.Character;
using Entities.Road;
using Level.InitScriptableObjects;
using Services.Constants;
using Services.PoolObjectSystem.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Level
{
    [Serializable]
    public class SceneCreator
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject _policeCarPref;
        [SerializeField] private GameObject _catchesPref;
        
        [Header("Containers")] 
        [SerializeField] private Transform _catchesContainer;
        [SerializeField] private Transform _policeCarContainer;
        
        private RoadConfig _roadConfig;
        private CharacterConfig _characterConfig;
        
        private LevelData _levelData;

        public void Init(LevelConfig levelConfig,LevelData levelData)
        {
            _levelData = levelData;
            _roadConfig = levelConfig.RoadConfig;
            _characterConfig = levelConfig.CharacterConfig;
        }
        public void AssembleScene()
        {
            InitRoad();
            InitCharacter();
            CreateObjectPools();
        }
        private void InitRoad()
        {
            _levelData.Road.GetComponent<RoadManager>().Init(_roadConfig);
        }

        private void InitCharacter()
        {
            _levelData.Character.GetComponent<CharacterManager>().Initialize(_characterConfig);
        }

        private void CreateObjectPools()
        {
            _levelData.Obstacles.InitializePool(Const.BasicSizeOfPools,_catchesPref,_catchesContainer);
            _levelData.PoliceCar.InitializePool(Const.BasicSizeOfPools,_policeCarPref,_policeCarContainer);
        }

    }
}
