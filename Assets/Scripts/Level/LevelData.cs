using System;
using Level.InitScriptableObjects;
using Services.PoolObjectSystem.Pool;
using UnityEngine;
using UnityEngine.Pool;

namespace Level
{
    public class LevelData : MonoBehaviour
    {
        public static LevelData instance;
        
        [SerializeField] private int _gameScore;
        [SerializeField] private float _globalSpeed;

        [Header("ObjectPools")] 
        private ObjectPool _obstacles = new();
        private ObjectPool _policeCar = new();
        
        [Header("SceneEntities")]
        [SerializeField] private GameObject _character;
        [SerializeField] private GameObject _road;

        private int _bestScore;
        private int _characterHealth;
        private int _characterCoins;

        public int CharacterHealth
        {
            get => _characterHealth;
            set => _characterHealth = value;
        }

        public int CharacterCoins
        {
            get => _characterCoins;
            set => _characterCoins = value;
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

        public ObjectPool Obstacles
        {
            get => _obstacles;
            set => _obstacles = value;
        }

        public ObjectPool PoliceCar
        {
            get => _policeCar;
            set => _policeCar = value;
        }

        public GameObject Character
        {
            get => _character;
            set => _character = value;
        }

        public GameObject Road
        {
            get => _road;
            set => _road = value;
        }

        private void Awake()
        {
            instance = this;
        }
    }
}