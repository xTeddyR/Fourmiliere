﻿namespace FourmilliereAL.Core
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location()
        {
            X = 0;
            Y = 0;
        }
        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
