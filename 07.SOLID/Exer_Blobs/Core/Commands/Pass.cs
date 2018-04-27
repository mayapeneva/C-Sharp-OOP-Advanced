using System.Collections.Generic;

public class Pass : ICommand
{
    public Dictionary<string, Blob> Execute(string[] command, Dictionary<string, Blob> blobs)
    {
        return blobs;
    }
}