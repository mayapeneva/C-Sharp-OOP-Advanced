using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Trim().Split();

            var stack = new MyStack<string>();
            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Push":
                        stack.Push(input.Skip(1).Select(i => i.Trim(',', ' ')).ToArray());
                        break;

                    case "Pop":
                        stack.Pop();
                        break;
                }

                input = Console.ReadLine().Trim().Split();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}