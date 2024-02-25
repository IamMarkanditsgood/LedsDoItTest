using System.Collections;
using Entities.Character;
using UnityEngine;

namespace Entities.Skills
{
    public abstract class BasicCharacterSpeedRetarder : Catchable
    {

        protected void SlowDown(CharacterManager characterManager)
        {
            StartCoroutine(ActivateNitro(characterManager));
        }
        
        private IEnumerator ActivateNitro(CharacterManager characterManager)
        {
            characterManager.ChangeSpeed(amount, false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(timeOfUse);
            characterManager.ChangeSpeed(amount, true);
            Destroy(gameObject);

        }
    }
}