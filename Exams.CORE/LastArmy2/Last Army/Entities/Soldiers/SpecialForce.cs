using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const int RegenarateIncreaser = 20;
    private const double OverallSkillMiltiplier = 3.5;

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, OverallSkillMiltiplier)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };

    public override void Regenerate()
    {
        base.Regenerate();
        this.Endurance += RegenarateIncreaser;
    }
}