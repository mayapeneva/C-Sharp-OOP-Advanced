using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authros = authors;
    }

    public string Title { get; }
    public int Year { get; }
    public IReadOnlyList<string> Authros { get; }

    public int CompareTo(Book other)
    {
        var result = this.Year.CompareTo(other.Year);
        if (result != 0)
        {
            return result;
        }

        return String.Compare(this.Title, other.Title, StringComparison.InvariantCulture);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}