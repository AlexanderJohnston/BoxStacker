#region Header
// BoxStacker/Parser.cs - Created on 2018-02-15 at 11:39 PM by Alexander Johnston.
#endregion

#region Using
using System ;
using System.Collections.Generic ;
using System.Threading.Tasks ;
#endregion

namespace BoxStacker
{
    internal class Parser
    {
        #region Properties & Fields
        private string[] _inputs { get ; }
        #endregion

        #region Constructors
        public Parser (string[] args)
        {
            _inputs = args ;
            Task processNewInput = ParseInputAsync () ;
            processNewInput.ContinueWith (task => Console.WriteLine ("Done parsing." + " Success: " +
                                                                     task.IsCompletedSuccessfully)) ;
        }
        #endregion

        #region Members
        private async Task<IEnumerable<Sorter>> ParseInputAsync ()
        {
            foreach ( var input in _inputs ) Task
        }

        private async Task<(List<Stack> stacks, List<Box> boxes)> SplitInput (string input)
        {
            var boxes  = input.AsSpan ().Slice (2, input.Length - 2) ;
            var stacks = input.AsSpan ().Slice (0, 1) ;

            var boxSizes = ParseBoxes (boxes) ;
            CreateStacks (Convert.ToInt32 (stacks.Slice (0, 1))) ;
        }

        private ReadOnlySpan<int> ParseBoxes (ReadOnlySpan<char> boxChars)
        {
            var boxSizes = new int[boxChars.Length] ;
            for ( var i = boxChars.Length - 1 ; i >= 0 ; i-- )
                boxSizes[i] = Convert.ToInt32 (boxChars[i]) ;

            return boxSizes.AsSpan () ;
        }

        private void CreateStacks (int stackCount)
        {
            for ( var i = stackCount ; i > 0 ; i-- ) { }
        }
        #endregion
    }
}
