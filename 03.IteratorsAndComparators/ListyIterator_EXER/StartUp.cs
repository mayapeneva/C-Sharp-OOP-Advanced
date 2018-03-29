using System;
using System.Linq;

namespace ListyIterator_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Trim().Split();

            var collection = new ListyIterator<string>(input.Skip(1).ToArray());
            try
            {
                while (input[0] != "END")
                {
                    input = Console.ReadLine().Trim().Split();
                    switch (input[0])
                    {
                        case "Move":
                            Console.WriteLine(collection.Move());
                            break;

                        case "Print":
                            collection.Print();
                            break;

                        case "PrintAll":
                            foreach (var item in collection)
                            {
                                Console.Write($"{item} ");
                            }
                            Console.WriteLine();
                            break;

                        case "HasNext":
                            Console.WriteLine(collection.HasNext());
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}