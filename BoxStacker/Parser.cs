using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxStacker
{
    internal class Parser
    {
        private string[] _inputs { get; set; }

        public Parser(string[] args)
        {
            this._inputs = args;
            Task processNewInput = ParseInputAsync();
            processNewInput.ContinueWith((task) => Console.WriteLine("Done parsing." + " Success: " + task.IsCompletedSuccessfully));
        }

        private async Task<List<Sorter>> ParseInputAsync()
        {
            foreach (var input in _inputs)
            {
                Task 
            }
        }

        private async Task<(List<Stack> stacks, List<Box> box)> SplitInput(string input)
        {
            ReadOnlySpan<char> boxes = input.AsSpan().Slice(2, input.Length - 2);
            ReadOnlySpan<char> stacks = input.AsSpan().Slice(0, 1);

            var boxSizes = ParseBoxes(boxes);
            CreateStacks(Convert.ToInt32(stacks.Slice(0,1)));
        }

        private ReadOnlySpan<int> ParseBoxes(ReadOnlySpan<char> boxChars)
        {
            var boxSizes = new int[boxChars.Length];
            for (var i = boxChars.Length - 1; i >= 0; i--)
                boxSizes[i] = Convert.ToInt32(boxChars[i]); 

            return boxSizes.AsSpan();
        }

        private void CreateStacks(int stackCount)
        {
            for (int i = stackCount; i > 0; i--)
            {

            }
        }
    }
}