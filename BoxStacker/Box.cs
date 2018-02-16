#region Header
// BoxStacker/Box.cs - Created on 2018-02-07 at 6:11 PM by Alexander Johnston.
#endregion

namespace BoxStacker
{
    internal class Box
    {
        #region Properties & Fields
        public int Complement ;
        public int Size ;
        #endregion

        #region Constructors
        public Box (int size, int stackCapacity)
        {
            Size       = size ;
            Complement = stackCapacity - size ;
        }
        #endregion
    }
}
