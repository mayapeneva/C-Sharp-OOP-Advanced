using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var dp = new DetailsPrinter(new List<Employee> { new Employee("Pesho"), new Manager("Ivan", new List<string> { "1", "2", "3" }) });
        dp.printDetails();
    }
}