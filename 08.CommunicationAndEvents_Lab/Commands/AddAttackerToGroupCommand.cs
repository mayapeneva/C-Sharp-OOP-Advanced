public class AddAttackerToGroupCommand : ICommand
{
    private IAttackGroup attackGroup;
    private IAttacker attacker;

    public AddAttackerToGroupCommand(IAttackGroup attackGroup, IAttacker attacker)
    {
        this.attackGroup = attackGroup;
        this.attacker = attacker;
    }

    public void Execute()
    {
        this.attackGroup.AddMember(this.attacker);
    }
}