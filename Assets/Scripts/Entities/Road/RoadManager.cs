using System;
using Level;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Road
{
    public class RoadManager : MonoBehaviour
    {
        private float _scrollSpeedDivisor;

        public void Init(RoadConfig roadConfig)
        {
            _scrollSpeedDivisor = roadConfig.MovementSpeedDivisor;
        }
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float speed = LevelData.instance.GlobalSpeed * _scrollSpeedDivisor;
            float offset = Time.time * speed;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
        }
    }
}