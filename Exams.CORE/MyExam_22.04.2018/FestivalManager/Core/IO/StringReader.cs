namespace FestivalManager.Core.IO
{
    using Contracts;
    using System;

    public class StringReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}