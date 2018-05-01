public interface IWareHouse
{
    void AddAmmunitions(string ammunition, int qunatity);

    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);
}