using System.Collections;
using System.Numerics;
using Domain.Models;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Domain.GameRules
{
    public class GetChariotRotation
    {
        private bool isDelayForRotation = false;
        private Vector3 prevDirection = Vector3.up;
        public Vector3 Handle(MonoBehaviour mb, Chariot chariot, float rotateSpeed,float horizontalInput, float deltaTime)
        {
            if (!isDelayForRotation)
            {
                isDelayForRotation = true;
                mb.StartCoroutine(GetDirection(chariot));
            }

            return prevDirection * (horizontalInput * rotateSpeed * deltaTime);
        }

        private IEnumerator GetDirection(Chariot chariot)
        {
            yield return new WaitForSeconds(1f);
            
            if (chariot.Anger >= Random.Range(0, 100))
            {
                prevDirection = Vector3.down;
            }
            else prevDirection = Vector3.up;

            isDelayForRotation = false;
        }
    }
}