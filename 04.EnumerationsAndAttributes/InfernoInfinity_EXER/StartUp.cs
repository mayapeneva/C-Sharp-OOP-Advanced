using System;

namespace InfernoInfinity_EXER
{
    public class StartUp
    {
        public static void Main()
        {
        }

        private static void CallingCustomAttribute()
        {
            var input = Console.ReadLine();
            var attributes = typeof(CustomAttribute).GetCustomAttributes(false);
            while (input != "END")
            {
                foreach (CustomAttribute attribute in attributes)
                {
                    Console.WriteLine(attribute.Print(input));
                }

                input = Console.ReadLine();
            }
        }
    }
}