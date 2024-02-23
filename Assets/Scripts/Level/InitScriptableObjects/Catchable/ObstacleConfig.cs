using Entities.Character.Skills;
using Entities.Skills;
using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "Catch", menuName = "ScriptableObject/LevelConfigs/Catch", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField] private ObstacleTypes _type;
    }
}