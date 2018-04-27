public class Blob
{
    private int health;
    private readonly int initialHealth;
    private readonly int initialDamage;

    public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.Behavior = behavior;
        this.Attack = attack;

        this.initialHealth = health;
        this.initialDamage = damage;
    }

    public string Name { get; }

    public int Health
    {
        get => this.health;
        set
        {
            this.health = value;

            if (this.health < 0)
            {
                this.health = 0;
            }
        }
    }

    public IBehavior Behavior { get; }

    public int Damage { get; set; }

    public IAttack Attack { get; }

    public void Respond(int damage)
    {
        this.Health -= damage;
    }

    public bool IfTriggerBehavior()
    {
        if (this.health < this.initialHealth)
        {
            return true;
        }

        return false;
    }

    public void UpdateDamage()
    {
        if (this.Damage <= this.initialDamage)
        {
            this.Damage = this.initialDamage;
        }
    }

    public override string ToString()
    {
        if (this.Health <= 0)
        {
            return $"Blob {this.Name} KILLED";
        }

        return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
    }
}