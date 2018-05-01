public interface IWareHouse
{
    void AddAmmunition(string ammunitionName, int count);

    bool CanEquipSoldier(string type);

    void EquipArmy(IArmy army);
}