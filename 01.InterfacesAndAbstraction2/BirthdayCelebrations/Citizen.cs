﻿public class Citizen : IInhabitant, IBeing
{
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Name { get; }
    public string Birthdate { get; }
    public int Age { get; }
    public string Id { get; }
}