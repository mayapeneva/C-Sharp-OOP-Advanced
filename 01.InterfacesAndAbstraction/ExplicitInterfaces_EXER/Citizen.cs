namespace ExplicitInterfaces_EXER
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; }
        public int Age { get; }
        public string Country { get; }

        string IPerson.GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}