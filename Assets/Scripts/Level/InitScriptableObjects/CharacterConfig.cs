using System.Collections.Generic;
using Entities.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Level.InitScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "ScriptableObject/LevelConfigs/Character", order = 0)]
    public class CharacterConfig : SerializedScriptableObject
    {
        [SerializeField] private int _health;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _magnetRadius = 5f;
        [SerializeField] private float _magnetForce = 10f;
        [SerializeField] private Dictionary<CharacterSpriteType, Sprite> _carSprites;

        public int Health => _health;
        public float MagnetRadius => _magnetRadius;
        public float MagnetForce => _magnetForce;
        public float MovementSpeed => _movementSpeed;
        public Dictionary<CharacterSpriteType, Sprite> CarSprites => _carSprites;
    }
}