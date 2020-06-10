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

        public Float3(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Z = 0;
        }

        public static Float3 Zero { get => new Float3(0, 0, 0); }
    }
}
