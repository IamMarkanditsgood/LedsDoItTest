using Level.InitScriptableObjects;
using UnityEngine;

namespace Entities.Character.Skills
{
    public abstract class Catchable: MonoBehaviour
    {
        public abstract void Init(ObstacleConfig obstacleConfig);

        public abstract void Use(CharacterManager characterManager);
    }
}