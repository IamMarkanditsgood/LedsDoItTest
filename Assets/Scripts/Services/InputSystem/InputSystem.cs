using UnityEngine;

namespace Services.InputSystem
{
    public class InputSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public Vector2 GetInputDirection()
        {
            Vector2 direction;
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                direction = GetMoveButtons();
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                direction = SimpleInputAxis();
            }
            else
            {
                direction = GetMoveButtons();
            }
            
            return direction;
        }
        private Vector2 SimpleInputAxis() =>
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        
        private Vector2 GetMoveButtons()
        {
            Vector2 movement;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            return movement;
        }
    }
    
}