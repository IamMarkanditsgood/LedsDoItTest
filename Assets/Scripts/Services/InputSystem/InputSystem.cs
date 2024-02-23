using UnityEngine;

namespace Services.InputSystem
{
    public class InputSystem
    {
        public Vector2 GetMoveButtons()
        {
            Vector2 movement;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            return movement;
        }
    }
}