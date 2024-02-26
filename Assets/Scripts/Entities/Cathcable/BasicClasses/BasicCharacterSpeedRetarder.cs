using System.Collections;
using Entities.Character;
using Level;
using UnityEngine;

namespace Entities.Cathcable.BasicClasses
{
    public abstract class BasicCharacterSpeedRetarder : Catchable
    {
        protected void SlowDown(CharacterManager characterManager)
        {
            StartCoroutine(ActivateSlowDown(characterManager));
        }
        
        private IEnumerator ActivateSlowDown(CharacterManager characterManager)
        {
            SwitchSpeed(characterManager, false);
            
            yield return new WaitForSeconds(timeOfUse);
            
            SwitchSpeed(characterManager, true);
        }

        private void SwitchSpeed(CharacterManager characterManager, bool isActive)
        {
            characterManager.ChangeSpeed(2, isActive);
            gameObject.GetComponent<SpriteRenderer>().enabled = isActive;
        }
    }
}