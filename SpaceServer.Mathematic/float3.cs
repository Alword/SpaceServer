namespace SpaceServer.Mathematic
{
    public struct Float3
    {
        public float X;
        public float Y;
        public float Z;
        public Float3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Float3(float x, float z)
        {
            this.X = x;
            this.Y = 0;
            this.Z = z;
        }

        public static Float3 Zero { get => new Float3(0, 0, 0); }

        public static Float3 operator *(Float3 vector, float a)
        {
            vector.X *= a;
            vector.Y *= a;
            vector.Z *= a;
            return vector;
        }
    }
}
