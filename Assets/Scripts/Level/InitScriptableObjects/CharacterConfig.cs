using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObject/LevelConfigs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _health;
       

        public float MovementSpeed => _movementSpeed;
        public float Health => _health;
      
    }
}