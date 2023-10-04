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

        public int Anger
        {
            get => _anger;
            set => _anger = value > 100 ? 100 : value;
        }

        public int Sloth
        {
            get => _sloth;
            set => _sloth = value > 100 ? 100 : value;
        }

        private int _anger = 0;
        private int _sloth = 0;
    }
}