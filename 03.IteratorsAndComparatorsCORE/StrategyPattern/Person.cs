using System;

public class Person : IComparable<Person>
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
        var result = this.Name.Length.CompareTo(other.Name.Length);
        if (result == 0)
        {
            result = String.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}