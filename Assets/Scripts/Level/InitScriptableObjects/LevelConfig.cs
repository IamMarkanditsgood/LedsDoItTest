using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObject/LevelConfigs/Level", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private float _basicSceneSpeed;
        [SerializeField] private float _scoreTimer;
        [SerializeField] private float _obstacleSpawnTimer;
        [SerializeField] private float _obstacleSpawnInterval = 15f;
        [SerializeField] private float _policeSpawnTimer;
        [SerializeField] private float _policeSpawnInterval = 15f;

        [Header("Configs For Init")]
        [SerializeField] private RoadConfig _roadConfig;

        public float PoliceSpawnTimer
        {
            get => _policeSpawnTimer;
            set => _policeSpawnTimer = value;
        }

        public float PoliceSpawnInterval
        {
            get => _policeSpawnInterval;
            set => _policeSpawnInterval = value;
        }
        public RoadConfig RoadConfig
        {
            get => _roadConfig;
            set => _roadConfig = value;
        }

        public CharacterConfig CharacterConfig
        {
            get => _characterConfig;
            set => _characterConfig = value;
        }

        [SerializeField] private CharacterConfig _characterConfig;

        public float ScoreTimer
        {
            get => _scoreTimer;
            set => _scoreTimer = value;
        }

        public float ObstacleSpawnTimer
        {
            get => _obstacleSpawnTimer;
            set => _obstacleSpawnTimer = value;
        }

        public float ObstacleSpawnInterval
        {
            get => _obstacleSpawnInterval;
            set => _obstacleSpawnInterval = value;
        }


        public float BasicSceneSpeed
        {
            get => _basicSceneSpeed;
            set => _basicSceneSpeed = value;
        }
    }
}