using Entities.Character;
using Entities.Character.Skills.PoliceCar;
using Level;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Cathcable.BasicClasses
{
    public abstract class Catchable: MonoBehaviour
    {
        private readonly EntitiesMover _entitiesMover = new();
        
        private ObstacleConfig _obstacleConfig;
        
        protected int amount;
        protected float timeOfUse;
        
        private void FixedUpdate()
        {
            Move();
        }
        
        private void OnDisable()
        {
            Catchable currentScript = gameObject.GetComponent<Catchable>();
            Destroy(currentScript);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

        private void Move()
        {
            float speed = LevelData.instance.GlobalSpeed;
            _entitiesMover.Move(gameObject,speed,Vector2.down);
        }
        
        public virtual void Init(ObstacleConfig obstacleConfig)
        {
            _obstacleConfig = obstacleConfig;
            
            amount = _obstacleConfig.Amount;
            timeOfUse = _obstacleConfig.TimeOfUse;
            
            gameObject.GetComponent<SpriteRenderer>().sprite = obstacleConfig.Sprite;
        }

        public abstract void Use(CharacterManager characterManager);
    }
}