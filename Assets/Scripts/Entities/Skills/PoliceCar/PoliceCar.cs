using System;
using Entities.Character;
using Entities.Character.Skills;
using Entities.Character.Skills.PoliceCar;
using Level;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Skills.PoliceCar
{
    public class PoliceCar: BasicCharacterHealthThief
    {
        private readonly EntitiesMover _entitiesMover = new();
        
        private void FixedUpdate()
        {
            float speed = LevelData.instance.GlobalSpeed;
            _entitiesMover.Move(gameObject,speed,Vector2.up);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Killer"))
            {
                Destroy(gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Barier"))
            {
                Destroy(gameObject);
            }
            
        }

        public override void Use(CharacterManager characterManager)
        {
            SubtractAllHealth(characterManager);
            Destroy(gameObject);
        }
    }
}
