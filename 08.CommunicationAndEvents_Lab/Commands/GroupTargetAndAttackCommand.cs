public class GroupTargetAndAttackCommand : ICommand
{
    private IAttackGroup attackGroup;
    private ITarget target;

    public GroupTargetAndAttackCommand(IAttackGroup attackGroup, ITarget target)
    {
        this.attackGroup = attackGroup;
        this.target = target;
    }

    public void Execute()
    {
        this.attackGroup.GroupTargetAndAttack(this.target);
    }
}