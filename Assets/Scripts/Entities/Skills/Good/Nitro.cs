using System.Collections;
using System.Collections.Generic;
using Entities.Character.Skills.PoliceCar;
using Entities.Skills;
using Level;
using Level.InitScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities.Character.Skills
{
    public class Nitro : Catchable 
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
            Debug.Log(characterManager.IsSkillUsed);
            if (!characterManager.IsSkillUsed)
            {
                StartCoroutine(ActivateNitro(characterManager));
            }
        }
        private IEnumerator ActivateNitro(CharacterManager characterManager)
        {
            _isInUse = true;
            characterManager.IsSkillUsed = true;
            characterManager.RunSkill(ObstacleTypes.Nitro);
            characterManager.ChangeSpeed(amount, true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            characterManager.SetSprite(CharacterSpriteType.Nitro);
            yield return new WaitForSeconds(timeOfUse);
            characterManager.ChangeSpeed(amount, false);
            characterManager.IsSkillUsed = false;
            characterManager.SetSprite(CharacterSpriteType.Basic);
            _isInUse = false;
            Destroy(gameObject);

        }
    }
}