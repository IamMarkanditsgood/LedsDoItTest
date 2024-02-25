using Entities.Cathcable.BasicClasses;
using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using UnityEngine;

namespace Entities.Cathcable.PoliceCar
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
                LevelData.instance.PoliceCar.DisableComponent(gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Barier"))
            {
                LevelData.instance.PoliceCar.DisableComponent(gameObject);
            }
        }

        public override void Use(CharacterManager characterManager)
        {
            SubtractAllHealth(characterManager);
            LevelData.instance.PoliceCar.DisableComponent(gameObject);
        }
    }
}
