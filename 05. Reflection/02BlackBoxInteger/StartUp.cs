using System.Reflection;

namespace _02BlackBoxInteger
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            BlackBoxInt blackBox = (BlackBoxInt)Activator.CreateInstance(typeof(BlackBoxInt), true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split('_')[0];
                var number = int.Parse(input.Split('_')[1]);

                var method = typeof(BlackBoxInt).GetMethod(command,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                method.Invoke(blackBox, new object[] { number });

                var value = typeof(BlackBoxInt).GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(blackBox);
                Console.WriteLine(value);
            }
        }
    }
}