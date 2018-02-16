#region Header
// BoxStacker/Sorter.cs - Created on 2018-02-07 at 6:20 PM by Alexander Johnston.
#endregion

#region Using
using System ;
using System.Collections.Generic ;
#endregion

namespace BoxStacker
{
    internal class Sorter
    {
        #region Properties & Fields
        private readonly int _stackCapacity ;

        private readonly int _stackCount ;

        private List<Box> _boxPool ;

        private int[] _inputBoxes ;

        private List<Stack> _stacks ;
        #endregion

        #region Constructors
        public Sorter (int numberStacks, ReadOnlySpan<int> boxes)
        {
            _stackCount = numberStacks ;

            var sumSizes = 0 ;

            for ( var i = boxes.Length ; i > 0 ; i-- )
                sumSizes = sumSizes + boxes[i] ;

            _stackCapacity = sumSizes / numberStacks ;

            //FillBoxPool(boxes);

            //SortBoxes();
        }
        #endregion

        #region Members
        private void CreateStacks (int numberStacks)
        {
            for ( var i = numberStacks - 1 ; i >= 0 ; i-- )
                _stacks.Add (new Stack { Capacity = _stackCapacity }) ;
        }

        private void FillBoxPool (int[] boxes)
        {
            _inputBoxes = boxes ;

            foreach ( var box in boxes )
                _boxPool.Add (new Box (box, _stackCapacity)) ;
        }

        private void SortBoxes ()
        {
            CreateStacks (_stackCount) ;
        }
        #endregion
    }
}
