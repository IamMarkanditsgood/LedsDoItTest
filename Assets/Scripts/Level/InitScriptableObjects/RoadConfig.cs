using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "RoadConfig", menuName = "ScriptableObject/LevelConfigs/Road", order = 0)]
    public class RoadConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeedDivisorDivisor;

        public float MovementSpeedDivisor => _movementSpeedDivisorDivisor;
    }
}