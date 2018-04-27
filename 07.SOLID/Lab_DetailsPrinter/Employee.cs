public class Employee : IEmployee
{
    private readonly string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public virtual string PrintDetails()
    {
        return this.name;
    }
}