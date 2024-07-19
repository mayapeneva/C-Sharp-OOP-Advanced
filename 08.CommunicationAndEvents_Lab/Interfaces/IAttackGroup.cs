public interface IAttackGroup
{
    void AddMember(IAttacker attacker);

    void GroupAttack();

    void GroupTarget(ITarget target);

    void GroupTargetAndAttack(ITarget target);
}