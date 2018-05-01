using System;
using System.Collections.Generic;

public interface IManager
{
    string AddHero(List<String> arguments);

    string AddItemToHero(List<String> arguments);

    string AddRecipeToHero(List<String> arguments);

    string Inspect(List<String> arguments);

    string GenerateReport();
}