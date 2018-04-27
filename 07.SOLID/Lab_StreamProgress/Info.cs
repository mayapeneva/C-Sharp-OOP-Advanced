public abstract class Info : IInfo
{
    private string name;

    protected Info(string name, int length, int bytesSent)
    {
        this.name = name;
        this.Length = length;
        this.BytesSent = bytesSent;
    }

    public int Length { get; }
    public int BytesSent { get; }
}