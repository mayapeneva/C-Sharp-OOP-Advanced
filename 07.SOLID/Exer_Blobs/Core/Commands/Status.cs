using System;
using System.Collections.Generic;

public class Status : ICommand
{
    public Dictionary<string, Blob> Execute(string[] command, Dictionary<string, Blob> blobs)
    {
        foreach (var blob in blobs)
        {
            Console.WriteLine(blob.Value);
        }

        return blobs;
    }
}