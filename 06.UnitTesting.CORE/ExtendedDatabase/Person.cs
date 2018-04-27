using System;

public class Person : IEquatable<Person>
{
    public Person(long id, string username)
    {
        this.Id = id;
        this.Username = username;
    }

    public long Id { get; }
    public string Username { get; }

    public bool Equals(Person other)
    {
        var compare = this.Username.Equals(other.Username);
        if (compare)
        {
            compare = this.Id.Equals(other.Id);
        }

        return compare;
    }
}