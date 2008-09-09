using System;

namespace MvcApplication
{
    public class Rover
    {
        public virtual void Bark(int loudness)
        {
            // Make loud noise
        }

        public virtual void Fetch(int speed)
        {
            // Fetch something
            throw new Exception("Yikes!");
        }
    }
}