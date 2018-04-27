using System.Collections.Generic;

public interface IWareHouse
{
    IDictionary<string, int> Ammunitions { get; }

    void AddAmmunition(string name, int count);

    void EquipArmy(IArmy army);
}