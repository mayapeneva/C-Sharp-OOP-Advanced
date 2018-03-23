public class Smartphone : ICallable, IBrowsable
{
    public string Call()
    {
        return "Calling... ";
    }

    public string Browse()
    {
        return "Browsing: ";
    }
}