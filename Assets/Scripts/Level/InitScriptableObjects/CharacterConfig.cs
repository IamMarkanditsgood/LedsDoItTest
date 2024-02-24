using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObject/LevelConfigs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private int _health;
       

        public float MovementSpeed => _movementSpeed;
        public int Health => _health;
      
    }
}