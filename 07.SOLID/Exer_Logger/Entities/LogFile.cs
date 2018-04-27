using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger.Entities
{
    public class LogFile
    {
        private const string FileName = "log.txt";
        private readonly StringBuilder logBuilder;
        private int size;
        private int messageNumber;

        public LogFile()
        {
            this.logBuilder = new StringBuilder();
        }

        public int MessageNumber => this.messageNumber;

        public int Size => this.size;

        public void Write(string message)
        {
            this.logBuilder.Append(message);
            File.AppendAllText(FileName, message + Environment.NewLine);
            this.UpdateSize(message);
        }

        private void UpdateSize(string message)
        {
            this.size += message.Where(char.IsLetter).Sum(c => c);
            this.messageNumber++;
        }
    }
}