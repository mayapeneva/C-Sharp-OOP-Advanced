using System;

namespace CustomList
{
    public class CommandInterpreter
    {
        private CustomList<string> customList;
        private Sorter sorter;

        public CommandInterpreter()
        {
            this.customList = new CustomList<string>();
            this.sorter = new Sorter(this.customList);
        }

        public void InterpretCommand(string input)
        {
            var tokens = input.Split();
            switch (tokens[0])
            {
                case "Add":
                    this.customList.Add(tokens[1]);
                    break;

                case "Remove":
                    this.customList.Remove(int.Parse(tokens[1]));
                    break;

                case "Contains":
                    Console.WriteLine(this.customList.Contains(tokens[1]));
                    break;

                case "Swap":
                    this.customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;

                case "Greater":
                    Console.WriteLine(this.customList.CountGreaterThan(tokens[1]));
                    break;

                case "Max":
                    Console.WriteLine(this.customList.Max());
                    break;

                case "Min":
                    Console.WriteLine(this.customList.Min());
                    break;

                case "Print":
                    Console.WriteLine(this.customList.ToString());
                    break;

                case "Sort":
                    this.sorter.Sort();
                    break;
            }
        }
    }
}