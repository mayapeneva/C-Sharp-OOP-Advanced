using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly IAmmunitionFactory ammunitionFactory;
    private readonly Dictionary<string, int> ammunitions;

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.ammunitions = new Dictionary<string, int>();
    }

    public void AddAmmunitions(string ammunition, int quantity)
    {
        if (!this.ammunitions.ContainsKey(ammunition))
        {
            this.ammunitions[ammunition] = 0;
        }

        this.ammunitions[ammunition] += quantity;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var weaponList = new List<IAmmunition>();

        foreach (var weaponName in soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key))
        {
            if (this.ammunitions.ContainsKey(weaponName) && this.ammunitions[weaponName] > 0)
            {
                var weapon = this.ammunitionFactory.CreateAmmunition(weaponName);
                weaponList.Add(weapon);
                this.ammunitions[weaponName]--;
            }
            else
            {
                return false;
            }
        }

        foreach (var ammunition in weaponList)
        {
            soldier.Weapons[ammunition.Name] = ammunition;
        }

        return true;
    }
}