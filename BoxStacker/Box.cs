namespace BoxStacker
{
    internal class Box
    {
        public int Size;

        public int Complement;

        public Box(int size, int stackCapacity)
        {
            Size = size;
            Complement = stackCapacity - size;
        }
    }
}