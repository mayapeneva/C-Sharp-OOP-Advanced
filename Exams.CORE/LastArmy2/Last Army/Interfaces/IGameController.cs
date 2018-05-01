using System.Collections.Generic;

public interface IGameController
{
    string Mission(List<string> arguments);

    string Soldier(List<string> arguments);

    string WareHouse(List<string> arguments);

    string RequestResult();
}