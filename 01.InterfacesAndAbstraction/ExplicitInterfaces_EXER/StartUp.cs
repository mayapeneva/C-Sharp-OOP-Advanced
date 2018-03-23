using System;

namespace ExplicitInterfaces_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);
                var citizen = new Citizen(name, country, age);

                IPerson pCitizen = citizen;
                Console.WriteLine(pCitizen.GetName());

                IResident rCitizen = citizen;
                Console.WriteLine(rCitizen.GetName());

                input = Console.ReadLine().Split();
            }
        }
    }
}