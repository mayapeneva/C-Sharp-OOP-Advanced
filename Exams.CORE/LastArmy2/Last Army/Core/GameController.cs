using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private const string CommandSifx = "Command";
    private const string Regenerate = "Regenerate";

    private readonly MissionController controller;
    private readonly IArmy army;
    private readonly IWareHouse wareHouse;
    private readonly MissionFactory missionFactory;

    public GameController(MissionController controller, IArmy army, IWareHouse wareHouse)
    {
        this.controller = controller;
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionFactory = new MissionFactory();
    }

    public string Mission(List<string> arguments)
    {
        var type = arguments[0];
        var scoreToComplete = double.Parse(arguments[1]);
        var mission = this.missionFactory.CreateMission(type, scoreToComplete);
        return this.controller.PerformMission(mission);
    }

    public string Soldier(List<string> arguments)
    {
        if (arguments[0].Equals(Regenerate))
        {
            var soldierType = arguments[1];
            this.army.RegenerateTeam(soldierType);
        }
        else
        {
            var type = arguments[0];
            var name = arguments[1];
            var age = int.Parse(arguments[2]);
            var experience = double.Parse(arguments[3]);
            var endurance = double.Parse(arguments[4]);

            if (this.wareHouse.CanEquipSoldier(type))
            {
                this.army.AddSoldier(type, name, age, experience, endurance);
            }
            else
            {
                return string.Format(OutputMessages.CannotEquipSoldier, type, name);
            }
        }

        return string.Empty;
    }

    public string WareHouse(List<string> arguments)
    {
        var name = arguments[0];
        var count = int.Parse(arguments[1]);
        this.wareHouse.AddAmmunition(name, count);
        return string.Empty;
    }

    public string RequestResult()
    {
        this.controller.FailMissionsOnHold();

        var result = new StringBuilder();
        result.AppendLine(string.Format(OutputMessages.Results));
        result.AppendLine(string.Format(OutputMessages.SuccessfulMissions, this.controller.SuccessMissionCounter));
        result.AppendLine(string.Format(OutputMessages.FailedMissions, this.controller.FailedMissionCounter));

        result.AppendLine(string.Format(OutputMessages.Soldiers));
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            result.AppendLine(soldier.ToString().Trim());
        }

        return result.ToString().Trim();
    }
}