public class StreamProgressInfo
{
    private readonly IInfo info;

    public StreamProgressInfo(IInfo file)
    {
        this.info = file;
    }

    public int CalculateCurrentPercent()
    {
        return (this.info.BytesSent * 100) / this.info.Length;
    }
}