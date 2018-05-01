using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int RegenarateIncreaser = 10;

    private double endurance;
    private readonly double overallSkillMiltiplier;
    private readonly IAmmunitionFactory factory;

    protected Soldier(string name, int age, double experience, double endurance, double overallSkillMiltiplier)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.overallSkillMiltiplier = overallSkillMiltiplier;

        this.factory = new AmmunitionFactory();
        this.WeaponsSetUp();
    }

    public string Name { get; }
    public int Age { get; }
    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set => this.endurance = Math.Min(value, 100);
    }

    public double OverallSkill => (this.Age + this.Experience) * this.overallSkillMiltiplier;

    public IDictionary<string, IAmmunition> Weapons { get; private set; }
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    private void WeaponsSetUp()
    {
        this.Weapons = new Dictionary<string, IAmmunition>();
        foreach (var weaponName in this.WeaponsAllowed)
        {
            this.Weapons[weaponName] = this.factory.CreateAmmunition(weaponName);
        }
    }

    public virtual void Regenerate()
    {
        this.Endurance += this.Age + RegenarateIncreaser;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;
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

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}