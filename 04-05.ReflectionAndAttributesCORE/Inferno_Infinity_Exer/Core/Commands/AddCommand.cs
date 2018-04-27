using System;

public class AddCommand : ICommand
{
    public void Execute(string[] args, Repository repository)
    {
        var weaponName = args[0];
        var weapon = repository.GetWeapon(weaponName);

        var socketIndex = int.Parse(args[1]);

        var gemData = args[2].Split();
        var ifParsed = Enum.TryParse(gemData[0], out GemClarity clarity);
        var gemType = gemData[1];

        if (ifParsed)
        {
            var classType = Type.GetType(gemType);
            var gem = (IGem)Activator.CreateInstance(classType, new object[] { clarity });
            weapon.AddGem(gem, socketIndex);
        }
    }
}