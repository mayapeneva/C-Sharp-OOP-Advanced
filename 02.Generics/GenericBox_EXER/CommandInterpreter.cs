using System;

namespace GenericBox_EXER
{
    public class CommandInterpreter
    {
        private Box<string> box;

        public CommandInterpreter(Box<string> box)
        {
            this.box = box;
        }

        public void Interpred(string[] input)
        {
            switch (input[0])
            {
                case "Add":
                    this.box.Add(input[1]);
                    break;

                case "Remove":
                    this.box.Remove(int.Parse(input[1]));
                    break;

                case "Contains":
                    Console.WriteLine(this.box.Contains(input[1]));
                    break;

                case "Swap":
                    this.box.SwapElements(int.Parse(input[1]), int.Parse(input[2]));
                    break;

                case "Greater":
                    Console.WriteLine(this.box.CountGreaterEmelements(input[1]));
                    break;

                case "Max":
                    Console.WriteLine(this.box.Max());
                    break;

                case "Min":
                    Console.WriteLine(this.box.Min());
                    break;

                case "Sort":
                    var sorter = new Sorter();
                    this.box.Collection = sorter.Sort(this.box);
                    break;

                case "Print":
                    Console.WriteLine(this.box.Print());
                    break;
            }
        }
    }
}