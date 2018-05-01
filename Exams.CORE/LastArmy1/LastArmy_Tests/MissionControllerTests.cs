using NUnit.Framework;
using System;

public class LastArmyTests
{
    private MissionController controller;

    [SetUp]
    public void InitialTest()
    {
        IArmy army = new Army();
        army.AddSoldier(new Ranker("Ivan", 47, 23, 100));
        army.AddSoldier(new Corporal("Ivaylo", 21, 78, 100));

        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();

        IWareHouse warehouse = new WareHouse(ammunitionFactory);
        warehouse.AddAmmunitions("Gun", 2);
        warehouse.AddAmmunitions("AutomaticMachine", 2);
        warehouse.AddAmmunitions("MachineGun", 1);
        warehouse.AddAmmunitions("Helmet", 2);
        warehouse.AddAmmunitions("Knife", 1);

        this.controller = new MissionController(army, warehouse);
    }

    [Test]
    public void Constr_ShouldInitializeMissions()
    {
        IMission mission = new Easy(100);
        var expected = 0;

        Assert.AreEqual(expected, this.controller.Missions.Count);
    }

    [Test]
    public void PerformMission_MissionShouldBePerformed()
    {
        IMission mission = new Easy(100);
        var expected = $"Mission completed - {mission.Name}{Environment.NewLine}";

        Assert.AreEqual(expected, this.controller.PerformMission(mission));
    }

    [Test]
    public void PerformMission_MissionShouldFail()
    {
        IMission mission = new Easy(1500);
        var expected = $"Mission on hold - {mission.Name}{Environment.NewLine}";

        Assert.AreEqual(expected, this.controller.PerformMission(mission));
    }

    [Test]
    public void PerformMission_ShouldHaveNoMoreThen3MissionsOnHold()
    {
        IMission mission = new Medium(1400);
        var result = this.controller.PerformMission(mission);
        result = this.controller.PerformMission(new Easy(1200));
        result = this.controller.PerformMission(new Easy(1500));
        var mission2 = new Easy(1300);
        var expected = 3;

        Assert.AreEqual(expected, this.controller.Missions.Count);
    }

    [Test]
    public void PerformMission_FirstMissionShouldBeDeclined()
    {
        IMission mission = new Medium(1400);
        var result = this.controller.PerformMission(mission);
        result = this.controller.PerformMission(new Easy(1200));
        result = this.controller.PerformMission(new Easy(1500));
        var mission2 = new Easy(1300);
        var expected = $"Mission declined - {mission.Name}{Environment.NewLine}Mission on hold - {mission2.Name}{Environment.NewLine}Mission on hold - {mission2.Name}{Environment.NewLine}Mission on hold - {mission2.Name}{Environment.NewLine}";

        Assert.AreEqual(expected, this.controller.PerformMission(mission2));
    }
}