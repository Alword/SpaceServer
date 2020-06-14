using System;

namespace SpaceServer.Mathematic
{
    public struct Int2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Int2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Int2 obj)
        {
            return X == obj.X &&
                   Y == obj.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Int2 @int &&
                   Equals(@int);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Int2 left, Int2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Int2 left, Int2 right)
        {
            return !left.Equals(right);
        }
    }
}
