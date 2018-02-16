#region Header
// BoxStacker/Program.cs - Created on 2018-02-07 at 5:34 PM by Alexander Johnston.
#endregion

#region Using
using System ;
using System.Collections.Generic ;
using System.Linq ;
#endregion

namespace BoxStacker
{
    internal class Program
    {
        #region Members
        private static void Main (string[] args)
        {
            Console.WriteLine ("Hello Sorter!") ;

            List<string> individualStacks = ParseInput (args) ;

            var sorter = new Sorter () ;
        }

        private static IEnumerable<string> ParseInput (string[] args)
        {
            return args.OrderBy (value => value) ;
        }
        #endregion
    }
}
