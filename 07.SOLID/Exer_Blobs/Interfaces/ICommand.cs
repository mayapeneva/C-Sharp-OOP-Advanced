using System.Collections.Generic;

public interface ICommand
{
    Dictionary<string, Blob> Execute(string[] command, Dictionary<string, Blob> blobs);
}