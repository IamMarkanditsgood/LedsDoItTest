using Services.Interface;
using UnityEngine;

namespace Entities.Road
{
    public class  RoadMover : IMovable
    {
        public void Move(GameObject movableObject, float speed, Vector2 direction)
        {
            Transform movableObj = movableObject.transform;
            movableObj.Translate(direction * speed * Time.deltaTime);
            movableObj.position =  new Vector3(0f, movableObject.transform.position.y, movableObj.position.z);
        }
    }
}