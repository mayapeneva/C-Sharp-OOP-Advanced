using System.Collections.Generic;

public class Group : IAttackGroup
{
    private List<IAttacker> attackers;

    public Group(List<IAttacker> attackers)
    {
        this.attackers = attackers;
    }

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public void GroupAttack()
    {
        foreach (var attacker in this.attackers)
        {
            attacker.Attack();
        }
    }

    public void GroupTarget(ITarget target)
    {
        foreach (var attacker in this.attackers)
        {
            attacker.SetTarget(target);
        }
    }

    public void GroupTargetAndAttack(ITarget target)
    {
        foreach (var attacker in this.attackers)
        {
            attacker.SetTarget(target);
            attacker.Attack();
        }
    }
}