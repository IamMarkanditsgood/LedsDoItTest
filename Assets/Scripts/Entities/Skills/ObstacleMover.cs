using System;
using Services.Interface;
using UnityEngine;

namespace Entities.Character.Skills.PoliceCar
{
    [Serializable]
    public class ObstacleMover : IMovable
    {
        public void Move(GameObject movableObject, float speed, Vector2 direction)
        {
            movableObject.transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}