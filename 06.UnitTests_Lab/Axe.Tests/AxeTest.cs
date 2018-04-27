using NUnit.Framework;
using System;

[TestFixture]
public class AxeTest
{
    private const int AxeAttack = 10;
    private const int AxeDurability = 10;
    private const int DummyHealth = 20;
    private const int DummyExperience = 20;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitialTest()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        this.axe.Attack(this.dummy);

        Assert.AreEqual(9, this.axe.DurabilityPoints, "Axe durability doesn't change after attack");
    }

    public void AttackWithABrokenAxe()
    {
        this.axe.Attack(this.dummy);

        Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.dummy));
    }
}