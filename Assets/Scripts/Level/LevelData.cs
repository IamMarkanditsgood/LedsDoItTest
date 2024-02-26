using System;
using System.Collections.Generic;
using Entities.Road;
using Level.InitScriptableObjects;
using Level.InitScriptableObjects.Catchable;
using Services.PoolObjectSystem.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Level
{
    public class LevelData : MonoBehaviour
    {
        public static LevelData instance;
        
        [SerializeField] private ObstacleConfigList _obstacleConfigList;
        [SerializeField] private int _gameScore;
        [SerializeField] private float _globalSpeed;

        [Header("ObjectPools")] 
        private ObjectPool _obstacles = new();
        private ObjectPool _policeCar = new();
        
        [Header("SceneEntities")]
        [SerializeField] private GameObject _character;
        
        private int _bestScore;
        private int _characterHealth;
        private int _characterCoins;

        public bool IsGameStarted { get; set; }

        public ObstacleConfigList ObstacleConfigList => _obstacleConfigList;
        public ObjectPool Obstacles => _obstacles;
        public ObjectPool PoliceCar => _policeCar;
        public GameObject Character => _character;
        public int CharacterCoins
        {
            set => _characterCoins = value;
        }
        public int CharacterHealth
        {
            get => _characterHealth;
            set => _characterHealth = value;
        }
        public int BestScore
        {
            get => _bestScore;
            set => _bestScore = value;
        }
        public float GlobalSpeed
        {
            get => _globalSpeed;
            set => _globalSpeed = value;
        }
        public int GameScore
        {
            get => _gameScore;
            set => _gameScore = value;
        }
        private void Awake()
        {
            instance = this;
        }
    }
}