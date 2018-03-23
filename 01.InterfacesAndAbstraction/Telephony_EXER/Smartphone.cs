using System.Linq;

namespace Telephony_EXER
{
    public class Smartphone : IPhone, IWeb
    {
        public string CallANumber(string number)
        {
            if (number.ToCharArray().Any(char.IsLetter))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }

        public string BrowseAWebsite(string site)
        {
            if (site.ToCharArray().Any(char.IsDigit))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {site}!";
        }
    }
}