using System;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        var calendar = new WeeklyCalendar();
        calendar.AddEntry("Monday", "Internal meeting");
        calendar.AddEntry("Tuesday", "Create presentation");
        calendar.AddEntry("Tuesday", "Create lab and exercise");
        calendar.AddEntry("Thursday", "Enum Lecture");
        calendar.AddEntry("Monday", "Second internal meeting");

        foreach (var weeklyEntry in calendar.WeeklySchedule.OrderBy(n => n).ToList())
        {
            Console.WriteLine(weeklyEntry);
        }
    }
}