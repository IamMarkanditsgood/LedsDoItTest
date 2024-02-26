using Entities.Cathcable;
using UnityEngine;

namespace Level.InitScriptableObjects.Catchable
{
    [CreateAssetMenu(fileName = "Catch", menuName = "ScriptableObject/LevelConfigs/Catch", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _amount;
        [SerializeField] private float _timeOfUse;

        public int Amount => _amount;
        public float TimeOfUse => _timeOfUse;
        public Sprite Sprite => _sprite;
    }
}