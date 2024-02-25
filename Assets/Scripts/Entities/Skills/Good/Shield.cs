using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Character.Skills.PoliceCar;
using Entities.Skills;
using Level;
using Level.InitScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities.Character.Skills
{
    public class Shield: Catchable 
    {
        private readonly EntitiesMover _entitiesMover = new();
        
        private bool _isInUse;
        
        private void FixedUpdate()
        {
            float speed = LevelData.instance.GlobalSpeed;
            _entitiesMover.Move(gameObject,speed,Vector2.down);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && other.gameObject.CompareTag("Barier") && !_isInUse)
            {
                Destroy(gameObject);
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
            _isInUse = true;
            characterManager.IsSkillUsed = true;
            characterManager.RunSkill(ObstacleTypes.Shield);
            characterManager.IsShieldUsed = true;
            characterManager.SetSprite(CharacterSpriteType.Shield);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(timeOfUse);
            characterManager.IsShieldUsed = false;
            characterManager.IsSkillUsed = false;
            characterManager.SetSprite(CharacterSpriteType.Basic);
            _isInUse = false;
            Destroy(gameObject);

        }
    }
}