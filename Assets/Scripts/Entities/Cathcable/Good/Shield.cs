using System;
using System.Collections;
using System.Security.Cryptography;
using Entities.Cathcable.BasicClasses;
using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using UnityEngine;

namespace Entities.Cathcable.Good
{
    public class Shield: Catchable 
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
                StartCoroutine(ActivateNitro(characterManager));
            }
        }
        
        private IEnumerator ActivateNitro(CharacterManager characterManager)
        {
            characterManager.RunSkillInUI(ObstacleTypes.Shield);
            characterManager.SetSprite(CharacterSpriteType.Shield);
            SwitchMagnet(characterManager, true);
            
            yield return new WaitForSeconds(timeOfUse);
            
            characterManager.SetSprite(CharacterSpriteType.Basic);
            SwitchMagnet(characterManager, false);
            LevelData.instance.Obstacles.DisableComponent(gameObject);

        }
        
        private void SwitchMagnet(CharacterManager characterManager, bool isActive)
        {
            _isInUse = isActive;
            characterManager.IsSkillUsed = isActive;
            characterManager.IsShieldUsed = isActive;
            gameObject.GetComponent<SpriteRenderer>().enabled = !isActive;
        }
    }
}