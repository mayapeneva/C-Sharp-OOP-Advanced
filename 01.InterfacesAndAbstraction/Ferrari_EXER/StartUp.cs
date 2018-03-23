using System;

namespace Ferrari_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var driver = Console.ReadLine();
            ICar car = new Ferrari(driver);
            Console.WriteLine(car.ToString());
        }
    }
}