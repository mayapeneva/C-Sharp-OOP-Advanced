public class Citizen : IResident, IPerson
{
    private string name;

    public Citizen(string name, string country, int age)
    {
        this.name = name;
        this.Country = country;
        this.Age = age;
    }

    string IPerson.Name => this.name;
    string IResident.Name => this.name;
    public int Age { get; }

    public string Country { get; }

    string IPerson.GetName()
    {
        return this.name;
    }

    string IResident.GetName()
    {
        return "Mr/Ms/Mrs " + this.name;
    }
}