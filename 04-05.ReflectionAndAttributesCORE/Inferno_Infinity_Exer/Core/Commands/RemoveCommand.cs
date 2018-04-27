public class RemoveCommand : ICommand
{
    public void Execute(string[] args, Repository repository)
    {
        var weaponName = args[0];
        var socketIndex = int.Parse(args[1]);
        var weapon = repository.GetWeapon(weaponName);
        weapon.RemoveGem(socketIndex);
    }
}