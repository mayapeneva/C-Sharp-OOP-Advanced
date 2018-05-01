namespace RecyclingStation.WasteDisposal.IO
{
    using Interfaces;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}