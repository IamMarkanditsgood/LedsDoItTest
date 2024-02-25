using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObject/LevelConfigs/Level", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private float _basicSceneSpeed;
        [SerializeField] private float _scoreTimerAdd;
        [SerializeField] private float _obstacleSpawnInterval = 15f;
        [SerializeField] private float _policeSpawnInterval = 15f;

        public float PoliceSpawnInterval => _policeSpawnInterval;
        

        public CharacterConfig CharacterConfig
        {
            get => _characterConfig;
            set => _characterConfig = value;
        }

        [SerializeField] private CharacterConfig _characterConfig;

        public float ScoreTimerAdd
        {
            get => _scoreTimerAdd;
            set => _scoreTimerAdd = value;
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