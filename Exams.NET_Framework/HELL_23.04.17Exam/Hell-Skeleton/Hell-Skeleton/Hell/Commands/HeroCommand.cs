using System;
using System.Linq;
using System.Reflection;

public class HeroCommand : AbstractCommand
{
    private readonly string type;

    public HeroCommand(IManager heroManager, string name, string type)
        : base(heroManager, name)
    {
        this.type = type;
    }

    public override string Execute()
    {
        var heroType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(h => h.Name.Equals(this.type));

        var hero = (IHero)Activator.CreateInstance(heroType, this.Name);

        return this.HeroManager.AddHero(hero);
    }
}