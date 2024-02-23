﻿using System;
using Entities.Character.Skills;
using Level.InitScriptableObjects;
using Services.Constants;
using Services.Interface;
using UnityEditor;
using UnityEngine;

namespace Entities.Character
{
    
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _health;
        [SerializeField] private float _magnetRadius = 5f;
        [SerializeField] private float _magnetForce = 10f;
        [SerializeField] private int _coins;
        
        private bool _isMagnetUsed;
        private readonly IMovable _mover = new CharacterMover();
        private CatchManager _catchManager = new();

        public event Action OnDead;

        public bool IsMagnetUsed
        {
            get => _isMagnetUsed;
            set => _isMagnetUsed = value;
        }
        
        public void Initialize(CharacterConfig characterConfig)
        {
            _speed = characterConfig.MovementSpeed;
            _health = characterConfig.Health;
        }
        
        private void Update()
        {
            _mover.Move(gameObject, _speed, Vector2.zero);
            if (_isMagnetUsed)
            {
                UseMagnet();
            }

            CheckIfDead();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                if (other.gameObject.CompareTag("Killer"))
                {
                    SubtractHealth(Const.MaxCharacterHealth);
                }
                else
                {
                    _catchManager.Catch(other, this);
                }
            }
        }

        public void ChangeSpeed(int multiplier, bool increase)
        {
            if (multiplier == 0)
            {
                throw new ArgumentException("Multiplier cannot be zero.", nameof(multiplier));
            }

            _speed = increase ? _speed * multiplier : _speed / multiplier;
        }

        public void AddCoins(int amount)
        {
            _coins += amount;
        }
        public void AddHealth(int amount)
        {
            _health += amount;
            _health = Mathf.Min(_health, Const.MaxCharacterHealth);
        }
        public void SubtractHealth(int amount)
        {
            _health -= amount;
            _health = Mathf.Max(_health, Const.MinCharacterHealth);
        }

        private void CheckIfDead()
        {
            if (_health <= Const.MinCharacterHealth)
            {
                OnDead?.Invoke();
            }
        }
        private void UseMagnet()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _magnetRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Coin"))
                {
                    ApplyMagnetForce(collider.gameObject);
                }
            }
        }
        private void ApplyMagnetForce(GameObject coin)
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)coin.transform.position;
            coin.GetComponent<Rigidbody2D>().AddForce(direction.normalized * _magnetForce);

        }

        
    }
}