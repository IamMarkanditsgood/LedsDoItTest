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
        public Vector2 SimpleInputAxis() =>
            new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        
        public Vector2 GetMoveButtons()
        {
            Vector2 movement;
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            return movement;
        }
    }
    
}