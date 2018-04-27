using System.Collections.Generic;
using System.Linq;

public class Repository
{
    private readonly List<IWeapon> weapons;

    public void AddWeapon(IWeapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public IWeapon GetWeapon(string weaponName)
    {
        return this.weapons.First(w => w.Name.Equals(weaponName));
    }
}