using Services.Constants;
using UnityEngine;

namespace Entities.Character.Skills
{
    public abstract class BasicCharacterHealthThief : Catchable
    {
        protected void SubtractAllHealth(CharacterManager characterManager)
        {
            characterManager.SubtractHealth(Const.MaxCharacterHealth);
           
        }
    }
}