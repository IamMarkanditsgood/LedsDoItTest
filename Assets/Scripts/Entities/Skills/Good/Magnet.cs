using System.Collections;
using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using UnityEngine;

namespace Entities.Skills.Good
{
    public class Magnet:Catchable 
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
            characterManager.RunSkill(ObstacleTypes.Magnet);
            characterManager.IsMagnetUsed = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            characterManager.SetSprite(CharacterSpriteType.Magnet);
            yield return new WaitForSeconds(5);
            characterManager.IsMagnetUsed = false;
            characterManager.IsSkillUsed = false;
            characterManager.SetSprite(CharacterSpriteType.Basic);
            _isInUse = false;
            Destroy(gameObject);

        }
    }
}