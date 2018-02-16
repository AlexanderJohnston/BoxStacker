using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxStacker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sorter!");

            List<string> individualStacks = ParseInput(args);

            var sorter = new Sorter();
        }

        private static IEnumerable<string> ParseInput(string[] args) => args.OrderBy(value => value);
    }
}
