using System;
using System.Collections.Generic;
using Entities.Character.Skills.PoliceCar;
using Level;
using Level.InitScriptableObjects;
using Services.Interface;
using UnityEngine;

namespace Entities.Road
{
    public class RoadManager : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private List<GameObject> _road;
        
        private float _speed;
        private IMovable _roadMover = new RoadMover();
        
        
        private void FixedUpdate()
        {
            _speed = _levelData.GlobalSpeed;
            for (int i = 0; i < _road.Count; i++)
            {
                _roadMover.Move(_road[i], _speed,Vector2.down);
                IsGetTarget(_road[i]);
            }
        }

        private void IsGetTarget(GameObject movableObject)
        {
            float dist = Vector2.Distance(movableObject.transform.position, _endPosition.position);
            if (dist < 0.2f)
            {
                movableObject.transform.position = _startPosition.position;
            }
        }
    }
}