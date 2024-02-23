using Entities.Character;
using Entities.Character.Skills;
using Entities.Character.Skills.PoliceCar;
using Level;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Skills.Bad
{
    public class Block : BasicCharacterHealthThief
    {
        [SerializeField] private ObstacleConfig _obstacleConfig;
        private readonly ObstacleMover _obstacleMover = new();
        
        private void FixedUpdate()
        {
            float speed = LevelData.instance.GlobalSpeed;
            _obstacleMover.Move(gameObject,speed,Vector2.down);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Killer"))
            {
                Destroy(gameObject);
            }
        }
        public override void Init(ObstacleConfig obstacleConfig)
        {
            _obstacleConfig = obstacleConfig;
        }

        public override void Use(CharacterManager characterManager)
        {
            SubtractAllHealth(characterManager);
            Destroy(gameObject);
        }
    }
}