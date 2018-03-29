using System;
using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book first, Book second)
    {
        var result = String.Compare(first.Title, second.Title, StringComparison.InvariantCulture);
        if (result == 0)
        {
            return second.Year.CompareTo(first.Year);
        }

        return result;
    }
}