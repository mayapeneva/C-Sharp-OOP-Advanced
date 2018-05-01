using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory factory;

    public WareHouse()
    {
        this.Ammunitions = new Dictionary<string, int>();
        this.factory = new AmmunitionFactory();
    }

    public IDictionary<string, int> Ammunitions { get; }

    public void AddAmmunition(string ammunitionName, int count)
    {
        if (!this.Ammunitions.ContainsKey(ammunitionName))
        {
            this.Ammunitions[ammunitionName] = 0;
        }

        this.Ammunitions[ammunitionName] += count;
    }

    public bool CanEquipSoldier(string type)
    {
        var ammunitionsList = new List<string>();
        switch (type)
        {
            case "Ranker":
                ammunitionsList = new List<string> { "Gun", "AutomaticMachine", "Helmet" };
                break;

            case "Corporal":
                ammunitionsList = new List<string> { "Gun", "AutomaticMachine", "MachineGun", "Helmet", "Knife" };
                break;

            case "SpecialForce":
                ammunitionsList = new List<string> { "Gun", "AutomaticMachine", "MachineGun", "RPG", "Helmet", "Knife", "NightVision" };
                break;
        }

        foreach (var item in ammunitionsList)
        {
            if (this.Ammunitions[item] == 0)
            {
                return false;
            }
        }

        return true;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers.Where(s => s.Weapons.Values.Any(w => w.WearLevel <= 0)))
        {
            foreach (var weapon in soldier.Weapons.Values.Where(w => w.WearLevel <= 0))
            {
                if (this.Ammunitions[weapon.Name] > 0)
                {
                    weapon.ReChargeAmmunition();
                    this.Ammunitions[weapon.Name]--;
                }
            }
        }
    }
}