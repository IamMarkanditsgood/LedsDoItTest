using UnityEngine;

namespace Services.Interface
{
    public interface IMovable
    {
        public void Move(GameObject movableObject, float speed, Vector2 direction);
    }
}