using System.Collections;
using Entities.Cathcable.BasicClasses;
using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using UnityEngine;

namespace Entities.Cathcable.Good
{
    public class Nitro : Catchable 
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
            characterManager.RunSkillInUI(ObstacleTypes.Nitro);
            characterManager.SetSprite(CharacterSpriteType.Nitro);
            SwitchMagnet(characterManager, true);
            
            yield return new WaitForSeconds(timeOfUse);
            
            characterManager.ChangeSpeed(amount, false);
            characterManager.SetSprite(CharacterSpriteType.Basic);
            SwitchMagnet(characterManager, false);
            LevelData.instance.Obstacles.DisableComponent(gameObject);

        }
        
        private void SwitchMagnet(CharacterManager characterManager, bool isActive)
        {
            _isInUse = isActive;
            characterManager.IsSkillUsed = isActive;
            characterManager.ChangeSpeed(amount, isActive);
            gameObject.GetComponent<SpriteRenderer>().enabled = !isActive;
            
        }
    }
}