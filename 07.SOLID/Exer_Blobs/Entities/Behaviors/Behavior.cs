public abstract class Behavior : IBehavior
{
    protected Behavior()
    {
        this.ToDelayRecurrentEffect = true;
    }

    public int SourceInitialDamage { get; private set; }

    public bool IsTriggered { get; set; }

    public bool ToDelayRecurrentEffect { get; set; }

    public abstract void ApplyTriggerEffect(Blob source);

    public void Trigger(Blob source)
    {
        this.SourceInitialDamage = source.Damage;
        this.IsTriggered = true;
        this.ApplyTriggerEffect(source);
    }

    public abstract void ApplyRecurrentEffect(Blob source);
}