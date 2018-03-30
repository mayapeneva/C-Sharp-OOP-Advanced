using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic : IEnumerable<Pet>
{
    private readonly Pet[] pets;
    private int capacity;

    public Clinic(string name, int capacity)
    {
        this.Name = name;
        this.Capacity = capacity;
        this.pets = new Pet[this.Capacity];
    }

    public string Name { get; }

    public int Capacity
    {
        get => this.capacity;
        private set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.capacity = value;
        }
    }

    public bool AddPet(Pet pet)
    {
        if (!this.HasEmptyRooms())
        {
            return false;
        }

        var index = this.Capacity / 2;
        if (this.pets[index] == null)
        {
            this.pets[index] = pet;
            return true;
        }

        for (int i = 1; i <= index; i++)
        {
            if (this.pets[index - i] == null)
            {
                this.pets[index - i] = pet;
                return true;
            }

            if (this.pets[index + i] == null)
            {
                this.pets[index + i] = pet;
                return true;
            }
        }

        return false;
    }

    public bool ReleasePet()
    {
        if (this.pets.All(p => p == null))
        {
            return false;
        }

        var index = this.Capacity / 2;
        if (this.pets[index] != null)
        {
            this.pets[index] = null;
            return true;
        }

        for (int i = index + 1; i < this.Capacity; i++)
        {
            if (this.pets[i] != null)
            {
                this.pets[i] = null;
                return true;
            }
        }

        for (int j = 0; j < index; j++)
        {
            if (this.pets[j] != null)
            {
                this.pets[j] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.pets.Any(p => p == null);
    }

    public string Print(int room)
    {
        return this.pets[room] == null ? "Room empty" : this.pets[room].ToString();
    }

    public string Print()
    {
        var result = new StringBuilder();
        foreach (var pet in this.pets)
        {
            result.AppendLine(pet == null ? "Room empty" : pet.ToString());
        }

        return result.ToString().Trim();
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        foreach (var pet in this.pets)
        {
            yield return pet;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}