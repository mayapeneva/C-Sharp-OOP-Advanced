using System;

namespace LinkedListTraversal_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var linkedList = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var number = int.Parse(input[1]);

                switch (command)
                {
                    case "Add":
                        linkedList.Add(number);
                        break;

                    case "Remove":
                        linkedList.Remove(number);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}