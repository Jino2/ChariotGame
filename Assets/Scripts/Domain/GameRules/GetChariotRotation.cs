using Domain.Models;
using UnityEngine;

namespace Domain.GameRules
{
    public class GetChariotRotation
    {
        public Vector3 Handle(Chariot chariot, float rotateSpeed,float horizontalInput, float deltaTime)
        {
            Vector3 direction;
            if (chariot.Anger >= Random.Range(0, 100))
            {
                direction = Vector3.down;
            }
            else direction = Vector3.up;

            return direction * (horizontalInput * rotateSpeed * deltaTime);
        }
    }
}