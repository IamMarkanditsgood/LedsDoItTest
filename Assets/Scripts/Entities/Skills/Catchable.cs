using Entities.Character;
using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Skills
{
    public abstract class Catchable: MonoBehaviour
    {
        [SerializeField] private ObstacleConfig _obstacleConfig;
        [SerializeField]  protected int amount;
        [SerializeField]  protected float timeOfUse;
        
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