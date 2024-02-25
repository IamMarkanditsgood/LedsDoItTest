using Entities.Cathcable;
using Entities.Character.Skills;
using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "Catch", menuName = "ScriptableObject/LevelConfigs/Catch", order = 0)]
    public class ObstacleConfig : ScriptableObject
    {
        [SerializeField] private ObstacleTypes _type;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _amount;
        [SerializeField] private float _timeOfUse;

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public float TimeOfUse
        {
            get => _timeOfUse;
            set => _timeOfUse = value;
        }

        public ObstacleTypes Type => _type;

        public Sprite Sprite => _sprite;
    }
}