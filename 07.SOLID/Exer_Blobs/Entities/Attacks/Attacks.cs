public abstract class Attacks : IAttack
{
    public abstract void Execute(Blob attacker, Blob target);
}