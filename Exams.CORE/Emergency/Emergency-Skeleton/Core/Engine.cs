using System;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly EmergencyManagementSystem manager;

    public Engine(IReader reader, IWriter writer, EmergencyManagementSystem manager)
    {
        this.reader = reader;
        this.writer = writer;
        this.manager = manager;
    }

    public void Run()
    {
        string input;
        while ((input = this.reader.ReadLine()) != "EmergencyBreak")
        {
            var args = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            this.writer.WriteLine(this.manager.FindTheRightMethod(args));
        }
    }
}