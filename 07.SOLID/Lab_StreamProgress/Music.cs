public class Music : Info
{
    private string author;

    public Music(string name, string author, int length, int bytesSent)
        : base(name, length, bytesSent)
    {
        this.author = author;
    }
}