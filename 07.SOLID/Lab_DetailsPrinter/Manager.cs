using System;
using System.Collections.Generic;

public class Manager : Employee
{
    private readonly IReadOnlyCollection<string> documents;

    public Manager(string name, ICollection<string> documents)
        : base(name)
    {
        this.documents = new List<string>(documents);
    }

    public override string PrintDetails()
    {
        return base.PrintDetails() + Environment.NewLine + string.Join(Environment.NewLine, this.documents);
    }
}