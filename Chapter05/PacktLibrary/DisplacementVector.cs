namespace Packt.Shared
{
    public struct DisplacementVector
    {
        // If total bytes is 16 or less, your type only uses struct types for its fields, and you'll never want to derive from your type, USE STRUCT! otherwise you might want to use class
        public int X;
        public int Y;
        public DisplacementVector(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
        }

        public static DisplacementVector operator +(DisplacementVector vector1, DisplacementVector vector2)
        {
            return new DisplacementVector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }
    }
}