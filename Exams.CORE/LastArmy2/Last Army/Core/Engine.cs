using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine
{
    private readonly IGameController controller;
    private readonly IReader reader;
    private readonly IWriter writer;

    public Engine(IGameController controller, IReader reader, IWriter writer)
    {
        this.controller = controller;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        var result = new StringBuilder();
        string input;
        while (!(input = this.reader.ReadLine()).Equals("Enough! Pull back!"))
        {
            var arguments = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            try
            {
                var classType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(t => t == (typeof(IGameController)));
                var method = classType.GetMethods().FirstOrDefault(m => m.Name == arguments[0]);
                var output = method.Invoke(this.controller, new object[] { arguments.Skip(1).ToList() });
                if (output.ToString() != string.Empty)
                {
                    result.AppendLine(output.ToString());
                }
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }
        }

        result.AppendLine(this.controller.RequestResult());
        this.writer.WriteLine(result.ToString());
    }
}