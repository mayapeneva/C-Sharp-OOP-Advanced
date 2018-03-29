using System;
using System.Linq;

namespace Froggy_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var stones = new Lake<int>(input);

            Console.WriteLine(string.Join(", ", stones));
        }
    }
}