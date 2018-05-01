using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance, double overallSkill)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.FillWeaponList();
    }

    private IDictionary<string, IAmmunition> FillWeaponList()
    {
        var weapons = new Dictionary<string, IAmmunition>();
        foreach (var weapon in this.WeaponsAllowed)
        {
            weapons[weapon] = null;
        }

        return weapons;
    }

    public string Name { get; }
    public int Age { get; }
    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set
        {
            if (value > 100)
            {
                value = 100;
            }

            this.endurance = value;
        }
    }

    public virtual double OverallSkill => this.Experience + this.Age;
    public IDictionary<string, IAmmunition> Weapons { get; }
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) != 0;
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;
        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public abstract void Regenerate();

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}