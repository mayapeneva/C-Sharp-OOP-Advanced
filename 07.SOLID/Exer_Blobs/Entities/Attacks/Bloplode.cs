public class Blobplode : Attacks
{
    public override void Execute(Blob attacker, Blob target)
    {
        attacker.Health = attacker.Health - attacker.Health / 2;
        target.Respond(attacker.Damage * 2);

        if (target.Health < 1)
        {
            target.Health = 1;
        }
    }
}