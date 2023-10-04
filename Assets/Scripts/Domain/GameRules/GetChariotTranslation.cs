using System.Collections;
using System.Numerics;
using Domain.Models;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Domain.GameRules
{
    public class GetChariotTranslation
    {

        private bool isDelayForDirection = false;
        private Vector3 previousDirection = Vector3.forward;
        public Vector3 Handle(MonoBehaviour mb, Chariot chariot, float verticalInput, float deltaTime)
        {
            if(!isDelayForDirection)
            {
                isDelayForDirection = true;
                mb.StartCoroutine(GetTranslation(chariot));
            }
            return previousDirection * (verticalInput * deltaTime * chariot.Speed);
        }

        private IEnumerator GetTranslation(Chariot chariot)
        {
            yield return new WaitForSeconds(1f);
            var range = Random.Range(0, 100);
            if (chariot.Sloth >= range)
            {
                previousDirection = Vector3.zero;
            }
            else
            {
                previousDirection = Vector3.forward;
            }

            isDelayForDirection = false;
        }
    }
}