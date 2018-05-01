namespace FestivalManager.Core.IO
{
    using Contracts;
    using System;

    public class StringWriter : IWriter
    {
        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }

        public void Write(string contents)
        {
            Console.Write(contents);
        }
    }
}