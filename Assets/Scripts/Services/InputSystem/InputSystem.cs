using UnityEngine;

namespace Services.InputSystem
{
    public class InputSystem
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string MoveButton = "Move";
        private const string StopButton = "Stop";
        public Vector2 Axis { get; }
        
        public bool IsMove() => SimpleInput.GetButton(MoveButton);
        public bool IsStop() => SimpleInput.GetButton(StopButton);

        public Vector2 GetInputDirection()
        {
            Vector2 direction = Vector2.zero;
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                direction = GetMoveButtons();
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                direction = SimpleInputAxis();
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