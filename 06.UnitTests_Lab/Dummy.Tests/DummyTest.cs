using NUnit.Framework;
using System;

[TestFixture]
public class DummyTest
{
    private const int AxeAttack = 10;
    private const int AxeDurability = 10;
    private const int DummyHealth = 20;
    private const int DummyExperience = 20;

    private Axe axe;
    private Dummy dummy;

    public DummyTest()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [SetUp]
    public void InitialTest()
    {
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        this.dummy.TakeAttack(AxeAttack);

        Assert.AreEqual(10, this.dummy.Health, "Dummy health doesn't change");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        this.dummy.TakeAttack(2 * AxeAttack);

        Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(2 * AxeAttack));
    }

    [Test]
    public void DeadDummyCanGiveXp()
    {
        this.dummy.TakeAttack(2 * AxeAttack);

        Assert.AreEqual(20, this.dummy.GiveExperience(), "Dead Dummy doesn't give experience");
    }

    [Test]
    public void AliveDummyCantGiveXp()
    {
        Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
    }
}