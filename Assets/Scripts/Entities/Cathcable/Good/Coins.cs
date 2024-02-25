using Entities.Cathcable.BasicClasses;
using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using UnityEngine;

namespace Entities.Cathcable.Good
{
    public class Coins : Catchable
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Barier"))
            {
                LevelData.instance.Obstacles.DisableComponent(gameObject);
            }
        }
        
        public override void Use(CharacterManager characterManager)
        {
            characterManager.AddCoins(amount);
            LevelData.instance.Obstacles.DisableComponent(gameObject);
        }
    }
}