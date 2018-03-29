using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private readonly SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;
        private readonly List<Book> bookCollection;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.bookCollection = new List<Book>(books);
        }

        public Book Current => this.bookCollection[this.currentIndex];
        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.bookCollection.Count;
        }

        public void Reset() => this.currentIndex = -1;
    }
}