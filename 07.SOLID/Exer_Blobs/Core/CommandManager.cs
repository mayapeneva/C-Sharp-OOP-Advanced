using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

public class CommandManager
{
    private Dictionary<string, Blob> blobs;

    public CommandManager()
    {
        this.Blobs = blobs;
        this.blobs = new Dictionary<string, Blob>();
    }

    public Dictionary<string, Blob> Blobs
    {
        get => this.blobs;
        private set => this.blobs = value;
    }

    public void InterpredCommand(string[] commandtokens)
    {
        try
        {
            var commandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandtokens[0]);
            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == commandName);
            var command = (ICommand)Activator.CreateInstance(commandType);
            this.blobs = command.Execute(commandtokens, this.Blobs);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}