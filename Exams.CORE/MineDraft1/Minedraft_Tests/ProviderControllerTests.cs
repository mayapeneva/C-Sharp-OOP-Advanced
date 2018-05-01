using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class ProviderControllerTests

{
    private EnergyRepository repository;
    private ProviderController controller;

    [SetUp]
    public void Initial()
    {
        this.repository = new EnergyRepository();
        this.controller = new ProviderController(this.repository);
    }

    [Test]
    public void Register_ShouldRegisterProvider()
    {
        var providerDetails = new List<string> { "Pressure", "40", "100" };
        this.controller.Register(providerDetails);
        var expected = 1;

        Assert.AreEqual(expected, this.controller.Entities.Count);
    }

    //[Test]
    //public void Register_ShouldReturnCorrectMessage()
    //{
    //    var providerDetails = new List<string> { "Pressure", "40", "100" };
    //    var expected = "Successfully registered PressureProvider";

    //    Assert.AreEqual(expected, this.controller.Register(providerDetails));
    //}

    [Test]
    public void Produce_PressureProviderShouldProduceEnergy()
    {
        var providerDetails = new List<string> { "Pressure", "40", "100" };
        this.controller.Register(providerDetails);
        this.controller.Produce();
        var expected = 200;

        Assert.AreEqual(expected, this.controller.TotalEnergyProduced);
    }

    //[Test]
    //public void Produce_SolarProviderShouldProduceEnergy()
    //{
    //    var providerDetails = new List<string> { "Solar", "80", "100" };
    //    this.controller.Register(providerDetails);
    //    this.controller.Produce();
    //    var expected = 100;

    //    Assert.AreEqual(expected, this.controller.TotalEnergyProduced);
    //}

    //[Test]
    //public void Produce_ShouldRemovePressuerProviderIfNoDurability()
    //{
    //    var providerDetails = new List<string> { "Pressure", "40", "100" };
    //    this.controller.Register(providerDetails);
    //    for (int i = 0; i < 8; i++)
    //    {
    //        this.controller.Produce();
    //    }
    //    var expected = 0;

    //    Assert.AreEqual(expected, this.controller.Entities.Count);
    //}

    [Test]
    public void Produce_ShouldRemoveSolarProviderIfNoDurability()
    {
        var providerDetails = new List<string> { "Solar", "80", "100" };
        this.controller.Register(providerDetails);
        for (int i = 0; i < 16; i++)
        {
            this.controller.Produce();
        }
        var expected = 0;

        Assert.AreEqual(expected, this.controller.Entities.Count);
    }

    //[Test]
    //public void Produce_ShouldRemoveStandartProviderIfNoDurability()
    //{
    //    var providerDetails = new List<string> { "Standart", "10", "100" };
    //    this.controller.Register(providerDetails);
    //    for (int i = 0; i < 11; i++)
    //    {
    //        this.controller.Produce();
    //    }
    //    var expected = 0;

    //    Assert.AreEqual(expected, this.controller.Entities.Count);
    //}

    //[Test]
    //public void Produce_ShouldReturnCorrectMessage()
    //{
    //    var providerDetails = new List<string> { "Pressure", "40", "100" };
    //    this.controller.Register(providerDetails);
    //    var expected = "Produced 200 energy today!";

    //    Assert.AreEqual(expected, this.controller.Produce());
    //}

    [Test]
    public void Repair_ShouldRepairProvider()
    {
        var providerDetails = new List<string> { "Pressure", "40", "100" };
        this.controller.Register(providerDetails);
        var repairValue = 200;
        var expected = 900;

        this.controller.Repair(repairValue);

        Assert.AreEqual(expected, this.controller.Entities.First().Durability);
    }

    //[Test]
    //public void Repair_ShouldReturnCorrectMessage()
    //{
    //    var providerDetails = new List<string> { "Pressure", "40", "100" };
    //    this.controller.Register(providerDetails);
    //    var repairValue = 200;
    //    var expected = $"Providers are repaired by {repairValue}";

    //    Assert.AreEqual(expected, this.controller.Repair(repairValue));
    //}
}