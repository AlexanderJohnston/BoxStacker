using System.Collections.Generic;
using System.Linq;

namespace BoxStacker
{
    internal class Stack
    {
        public List<Box> boxes = new List<Box>();

        public int Capacity = 0;

        public int Size => this.boxes.Sum(box => box.Size);

        public int Deficit => this. Capacity - this.Size;

        public void Add(Box box)
        {
            if (this.Deficit >= box.Size)
                boxes.Add(box);
        }
    }
}