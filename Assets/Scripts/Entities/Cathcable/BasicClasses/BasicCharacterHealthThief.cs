using Entities.Character;
using Services.Constants;

namespace Entities.Cathcable.BasicClasses
{
    public abstract class BasicCharacterHealthThief : Catchable
    {
        protected void SubtractAllHealth(CharacterManager characterManager)
        {
            characterManager.SubtractHealth(Const.MaxCharacterHealth);
        }
    }
}