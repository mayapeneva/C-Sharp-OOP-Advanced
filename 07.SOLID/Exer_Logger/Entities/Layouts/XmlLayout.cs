using Logger.Interfaces;
using System.Text;

namespace Logger.Entities.Layouts
{
    public class XmlLayout : ILayout
    {
        public string DisplayLogs(string dataTime, string reportLevel, string message)
        {
            var result = new StringBuilder();
            result.AppendLine("<log>");
            result.AppendLine($"<data>{dataTime}</date>");
            result.AppendLine($"<level>{reportLevel}</level>");
            result.AppendLine($"<message>{message}</message>");
            result.AppendLine("</log>");

            return result.ToString().Trim();
        }
    }
}