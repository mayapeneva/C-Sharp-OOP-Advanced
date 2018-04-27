using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private string name;
    private int age;
    private double experience;
    private double endurance;
    private double overallSkill;
    private IDictionary<string, IAmmunition> weapons;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.name = name;
        this.age = age;
        this.experience = experience;
        this.endurance = endurance;
        this.weapons = new Dictionary<string, IAmmunition>();
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public double Experience
    {
        get { return this.experience; }
    }

    public double Endurance
    {
        get { return this.endurance; }
        set { this.endurance = value; }
    }

    public virtual double OverallSkill
    {
        get { return this.age + this.experience; }
    }

    public IDictionary<string, IAmmunition> Weapons
    {
        get { return this.weapons; }
    }

    public abstract IReadOnlyList<string> WeaponsAllowed { get; }
    public int Motivation { get; set; }
    public bool OnVacation { get; set; }
    public int SuccessMissionCounter { get; set; }
    public int Power { get; set; }

    public void Regenerate()
    {
    }

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

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {
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

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public void IncreaseSuccessMissionCounter()
    {
        throw new System.NotImplementedException();
    }

    public void IncreaseFailedMissionCounter()
    {
        throw new System.NotImplementedException();
    }

    public void GetBonus()
    {
        throw new System.NotImplementedException();
    }

    public void ComeBackFromVacation()
    {
        throw new System.NotImplementedException();
    }

    public void MakeStatsFull()
    {
        throw new System.NotImplementedException();
    }

    public bool CanCarryWeaponsTotalWeight(List<Ammunition> missionWeapons)
    {
        throw new System.NotImplementedException();
    }
}