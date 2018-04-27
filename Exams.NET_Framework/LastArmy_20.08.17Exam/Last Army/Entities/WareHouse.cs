using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    private IDictionary<string, int> ammunitions;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, int>();
    }

    public IDictionary<string, int> Ammunitions
    {
        get { return this.ammunitions; }
    }

    public void AddAmmunition(string name, int count)
    {
        if (!this.ammunitions.ContainsKey(name))
        {
            this.ammunitions[name] = 0;
        }

        this.ammunitions[name] += count;
    }

    public void EquipArmy(IArmy army)
    {
    }
}