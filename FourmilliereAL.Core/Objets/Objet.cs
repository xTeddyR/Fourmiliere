﻿namespace FourmilliereAL.Core
{
    public class Objet
    {
        public Location Position { get; set; }

        public Objet()
        {
            Position = new Location(0, 0);
        }

        public Objet(int x, int y)
        {
            Position = new Location(x, y);
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}