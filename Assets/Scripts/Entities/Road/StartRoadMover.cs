using Level;
using Services.Interface;
using UnityEngine;

namespace Entities.Road
{
    public class StartRoadMover : MonoBehaviour, IMovable
    {
        [SerializeField] private Transform _endPosition;
        private float _speed;
        
        private void Start()
        {
            _speed = LevelData.instance.GlobalSpeed;
        }

        public void Update()
        {
            if (LevelData.instance.IsGameStarted)
            {
                _speed = LevelData.instance.GlobalSpeed;
                Move(gameObject, _speed, Vector2.down);
                IsGetTarget(gameObject);
            }
        }

        public void Move(GameObject movableObject, float speed, Vector2 direction)
        {
            Transform movableObj = movableObject.transform;
            movableObj.Translate(direction * speed * Time.deltaTime);
            movableObj.position =  new Vector3(0f, movableObject.transform.position.y, movableObj.position.z);
        }
        
        private void IsGetTarget(GameObject movableObject)
        {
            float dist = Vector2.Distance(movableObject.transform.position, _endPosition.position);
            if (dist < 0.2f)
            {
                Destroy(gameObject);
            }
        }
    }
}