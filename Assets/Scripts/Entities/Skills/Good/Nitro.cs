using System.Collections;
using System.Collections.Generic;
using Entities.Character.Skills.PoliceCar;
using Level;
using Level.InitScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace Entities.Character.Skills
{
    public class Nitro : Catchable 
    {
        [SerializeField] private int _nitroMultiplier = 2;
        [SerializeField] private float _timeOfUse = 15f;
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
            
        }
        
        public override void Use(CharacterManager characterManager)
        {
            StartCoroutine(ActivateNitro(characterManager));
        }
        private IEnumerator ActivateNitro(CharacterManager characterManager)
        {
            characterManager.RunNitroTimer(_timeOfUse);
            characterManager.ChangeSpeed(_nitroMultiplier, true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(_timeOfUse);
            characterManager.ChangeSpeed(_nitroMultiplier, false);
            Destroy(gameObject);

        }
    }
}