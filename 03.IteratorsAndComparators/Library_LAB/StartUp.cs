using System;

public class StartUp
{
    public static void Main()
    {
        var firstBook = new Book("Animal Farm", 2003, "George Orwell");
        var secondBook = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
        var thirdBook = new Book("The Documents in the Case", 1930);

        var fullLibrary = new Library(firstBook, secondBook, thirdBook);

        foreach (var book in fullLibrary)
        {
            Console.WriteLine(book.ToString());
        }
    }
}