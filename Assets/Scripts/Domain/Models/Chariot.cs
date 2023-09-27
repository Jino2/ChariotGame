using System;

namespace Domain.Models
{
    public class Chariot
    {
        public Chariot(float speed, float patience, int anger, int sloth)
        {
            Speed = speed;
            Patience = patience;
            Anger = anger;
            Sloth = sloth;
        }

        public float Speed { get; }
        public float Patience { get; }

        public int Anger { get; set; }
        public int Sloth { get; set; }

        public void Whip()
        {
            Anger = Convert.ToInt32(Anger + 1 / Patience);
            Sloth /= 2;
        }
    }
}