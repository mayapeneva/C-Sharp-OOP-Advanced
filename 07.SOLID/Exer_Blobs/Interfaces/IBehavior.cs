public interface IBehavior
{
    int SourceInitialDamage { get; }

    bool IsTriggered { get; }

    bool ToDelayRecurrentEffect { get; }

    void ApplyTriggerEffect(Blob source);

    void Trigger(Blob source);

    void ApplyRecurrentEffect(Blob source);
}