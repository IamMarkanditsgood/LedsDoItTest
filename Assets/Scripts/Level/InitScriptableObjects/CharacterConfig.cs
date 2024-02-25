using System.Collections.Generic;
using Entities.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObject/LevelConfigs/Character", order = 0)]
    public class CharacterConfig : SerializedScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private int _health;
        [SerializeField] private Dictionary<CharacterSpriteType, Sprite> _carSprites;

        public Dictionary<CharacterSpriteType, Sprite> CarSprites => _carSprites;

        public float MovementSpeed => _movementSpeed;
        public int Health => _health;
      
    }
}