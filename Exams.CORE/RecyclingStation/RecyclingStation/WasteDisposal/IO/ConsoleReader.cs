namespace RecyclingStation.WasteDisposal.IO
{
    using Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}