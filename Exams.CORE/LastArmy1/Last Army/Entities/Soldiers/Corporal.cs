﻿using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private const double EnduranceIncreaser = 10;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "Helmet",
        "Knife",
    };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance, ((age + experience) * OverallSkillMiltiplier))
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public override void Regenerate()
    {
        base.Endurance += EnduranceIncreaser + base.Age;
    }
}