using System;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000;
    private const int MinDurability = 0;
    private const int DurabilityLoss = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }
    public double EnergyOutput { get; protected set; }

    public virtual double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < MinDurability)
            {
                throw new ArgumentException();
            }

            this.durability = value;
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= DurabilityLoss;
    }

    public void Repair(double value)
    {
        this.Durability += value;
    }

    public override string ToString()
    {
        return $"{this.GetType()}{Environment.NewLine}Durability: {this.Durability}";
    }
}