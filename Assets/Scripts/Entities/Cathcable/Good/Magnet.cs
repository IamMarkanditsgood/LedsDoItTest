using System.Collections;
using Entities.Cathcable.BasicClasses;
using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using UnityEngine;

namespace Entities.Cathcable.Good
{
    public class Magnet:Catchable 
    {
        private bool _isInUse;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Barier") && !_isInUse)
            {
                LevelData.instance.Obstacles.DisableComponent(gameObject);
            }
        }
        
        public override void Use(CharacterManager characterManager)
        {
            if (!characterManager.IsSkillUsed)
            {
                StartCoroutine(UseMagnet(characterManager));
            }
        }
        
        private IEnumerator UseMagnet(CharacterManager characterManager)
        {
            SwitchMagnet(characterManager, true);
            characterManager.RunSkill(ObstacleTypes.Magnet);
            characterManager.SetSprite(CharacterSpriteType.Magnet);
            
            yield return new WaitForSeconds(timeOfUse);
            
            SwitchMagnet(characterManager, false);
            characterManager.SetSprite(CharacterSpriteType.Basic);
            LevelData.instance.Obstacles.DisableComponent(gameObject);
        }

        private void SwitchMagnet(CharacterManager characterManager, bool isActive)
        {
            _isInUse = isActive;
            characterManager.IsSkillUsed = isActive;
            characterManager.IsMagnetUsed = isActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = !isActive;
            
        }
    }
}