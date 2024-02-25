using System.Collections.Generic;
using Entities.Cathcable;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Level.InitScriptableObjects.Catchable
{
    [CreateAssetMenu(fileName = "ObstacleList", menuName = "ScriptableObject/LevelConfigs/ObstacleList", order = 0)]
    public class ObstacleConfigList : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<ObstacleTypes, ObstacleConfig> _obstacleConfigs;

        public Dictionary<ObstacleTypes, ObstacleConfig> ObstacleConfigs
        {
            get => _obstacleConfigs;
            set => _obstacleConfigs = value;
        }
    }
}