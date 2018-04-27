using System;

public class CreateCommand : ICommand
{
    public void Execute(string[] args, Repository repository)
    {
        var weaponData = args[0].Split();
        var weaponType = weaponData[1];
        var ifparsed = Enum.TryParse(weaponData[0], out Rarity weaponRarity);
        var weaponName = args[1];

        if (ifparsed)
        {
            var classType = Type.GetType(weaponType);
            var weapon = (IWeapon)Activator.CreateInstance(classType, new object[] { weaponName, weaponRarity });
            repository.AddWeapon(weapon);
        }
    }
}