using System;

namespace GenericBox_EXER
{
    public class StartUp
    {
        private static void Main()
        {
            var interpreter = new CommandInterpreter(new Box<string>());
            var input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                interpreter.Interpred(input);

                input = Console.ReadLine().Split();
            }
        }
    }
}