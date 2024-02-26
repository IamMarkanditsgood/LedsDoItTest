using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObject/LevelConfigs/Level", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private CharacterConfig _characterConfig;
        [SerializeField] private float _basicSceneSpeed;
        [SerializeField] private float _scoreTimerAdd;
        [SerializeField] private float _obstacleSpawnInterval = 15f;
        [SerializeField] private float _policeSpawnInterval = 15f;
        [SerializeField] private float _startTimeEnd;

        public CharacterConfig CharacterConfig => _characterConfig;
        public float PoliceSpawnInterval => _policeSpawnInterval;
        public float ScoreTimerAdd => _scoreTimerAdd;
        public float ObstacleSpawnInterval => _obstacleSpawnInterval;
        public float BasicSceneSpeed => _basicSceneSpeed;
        public float StartTimeEnd => _startTimeEnd;
    }
}