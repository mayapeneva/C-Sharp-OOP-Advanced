using System;

namespace Telephony_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();

            var phone = new Smartphone();
            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(phone.CallANumber(number));
            }

            foreach (var site in websites)
            {
                Console.WriteLine(phone.BrowseAWebsite(site));
            }
        }
    }
}