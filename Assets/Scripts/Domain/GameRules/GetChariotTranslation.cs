using Domain.Models;
using UnityEngine;

namespace Domain.GameRules
{
    public class GetChariotTranslation
    {
        public Vector3 Handle(Chariot chariot, float verticalInput, float deltaTime)
        {
            var range = Random.Range(0, 100);
            if (chariot.Sloth >= range)
            {
                return Vector3.zero;
            }
            
            
            return Vector3.forward * (verticalInput * deltaTime * chariot.Speed);
        }
    }
}