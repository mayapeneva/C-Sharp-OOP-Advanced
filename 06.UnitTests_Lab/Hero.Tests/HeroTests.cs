using NUnit.Framework;
using Moq;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGetsExperienceAfterKillingTarget()
    {
        var weaponMock = new Mock<IWeapon>();
        weaponMock.Setup(w => w.Attack(It.IsAny<Dummy>()));
        var hero = new Hero("H", weaponMock.Object);

        var dummyMock = new Mock<ITarget>();
        dummyMock.Setup(d => d.GiveExperience()).Callback(() => dummyMock.Object.Health = 0);

        Assert.AreEqual(10, hero.Experience, "Hero is not getting experience after killing dummy");
    }
}