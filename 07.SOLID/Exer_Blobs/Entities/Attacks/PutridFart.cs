public class PutridFart : Attacks
{
    public override void Execute(Blob attacker, Blob target)
    {
        target.Respond(attacker.Damage);
    }
}