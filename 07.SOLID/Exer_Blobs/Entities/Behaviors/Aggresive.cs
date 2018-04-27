public class Aggressive : Behavior
{
    private static int AggressiveDamageMultiplier = 2;
    private static int AggressiveDamageDecrementer = 5;

    public override void ApplyTriggerEffect(Blob source)
    {
        source.Damage *= AggressiveDamageMultiplier;
    }

    public override void ApplyRecurrentEffect(Blob source)
    {
        if (this.ToDelayRecurrentEffect)
        {
            this.ToDelayRecurrentEffect = false;
        }
        else
        {
            source.Damage -= AggressiveDamageDecrementer;
            source.UpdateDamage();
        }
    }
}