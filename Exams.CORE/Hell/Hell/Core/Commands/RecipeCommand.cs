using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(List<string> arguments, IManager manager) : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddRecipeToHero(base.Arguments);
    }
}