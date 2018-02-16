#region Header
// BoxStacker/Stack.cs - Created on 2018-02-07 at 6:11 PM by Alexander Johnston.
#endregion

#region Using
using System.Collections.Generic ;
using System.Linq ;
#endregion

namespace BoxStacker
{
    internal class Stack
    {
        #region Properties & Fields
        public List<Box> boxes = new List<Box> () ;

        public int Capacity = 0 ;

        public int Size => boxes.Sum (box => box.Size) ;

        public int Deficit => Capacity - Size ;
        #endregion

        #region Members
        public void Add (Box box)
        {
            if ( Deficit >= box.Size )
                boxes.Add (box) ;
        }
        #endregion
    }
}
