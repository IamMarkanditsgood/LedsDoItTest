using System.Collections;
using UnityEngine;

namespace Entities.Character.Skills
{
    public abstract class BasicCharacterSpeedRetarder : Catchable
    {
        [SerializeField] private float _timeOfUse = 15f;
        
        protected void SlowDown(CharacterManager characterManager)
        {
            StartCoroutine(ActivateNitro(characterManager));
        }
        
        private IEnumerator ActivateNitro(CharacterManager characterManager)
        {
            characterManager.ChangeSpeed(2, false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(_timeOfUse);
            characterManager.ChangeSpeed(2, true);
            Destroy(gameObject);

        }
    }
}