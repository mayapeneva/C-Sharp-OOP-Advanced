using System;
using System.Linq;

public class Person : IEquatable<Person>, IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }
    public int Age { get; }

    public int CompareTo(Person other)
    {
        var result = String.Compare(this.Name, other.Name, StringComparison.InvariantCulture);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public bool Equals(Person other)
    {
        return this.Name.Equals(other.Name) && this.Age.Equals(other.Age);
    }

    public override int GetHashCode()
    {
        var hashCode = this.Name.Length * 10000;
        hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
        hashCode += this.Age * 10000;

        return hashCode;
    }
}