﻿using Entities.Character.Skills.PoliceCar;
using Level;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Character.Skills
{
    public class Coins : Catchable
    {
        [SerializeField] private int _amountOfCoins;
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
            characterManager.AddCoins(_amountOfCoins);
            Destroy(gameObject);
        }
    }
}