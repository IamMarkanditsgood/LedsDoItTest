﻿using Services.InputSystem;
using Services.Interface;
using UnityEngine;

namespace Entities.Character
{
    public class CharacterMover: IMovable
    {
        private readonly InputSystem _inputSystem = new();
        
        public void Move(GameObject movableObject, float speed,Vector2 direction)
        {
            Vector2 movement = _inputSystem.GetInputDirection().normalized;
            movableObject.transform.Translate(movement * speed * Time.deltaTime);
        }
    }
}