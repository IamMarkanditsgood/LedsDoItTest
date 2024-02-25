using System;
using Entities.Cathcable.BasicClasses;
using UnityEngine;

namespace Entities.Character.Skills
{
    [Serializable]
    public class CatchManager
    {
        public void Catch(Collider2D other, CharacterManager characterManager)
        {
            Catchable catchable = other.GetComponent<Catchable>();
            catchable.Use(characterManager);
        }
    }
}