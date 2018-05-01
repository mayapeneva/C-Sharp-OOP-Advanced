using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController
{
    private const string CommandSuffix = "Command";

    private readonly MissionController missionController;
    private readonly IWriter writer;

    private readonly IMissionFactory missionFactory;
    private readonly ISoldierFactory soldiersFactory;

    private readonly IArmy army;
    private readonly IWareHouse wareHouse;

    public GameController(MissionController missionController, IWriter writer, IMissionFactory missionFactory, ISoldierFactory soldiersFactory, IArmy army, IWareHouse wareHouse)
    {
        this.missionController = missionController;
        this.writer = writer;
        this.missionFactory = missionFactory;
        this.soldiersFactory = soldiersFactory;
        this.army = army;
        this.wareHouse = wareHouse;
    }

    public void ProcessInput(string input)
    {
        var data = input.Split().ToList();
        var commandType = data[0];
        data.RemoveAt(0);

        var commandFullName = commandType + CommandSuffix;

        try
        {
            this.GetType()
                .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, new object[] { data });
        }
        catch (TargetInvocationException exception)
        {
            throw exception.InnerException;
        }
    }

    private void WareHouseCommand(IList<string> data)
    {
        var name = data[0];
        var quantity = int.Parse(data[1]);
        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void SoldierCommand(IList<string> data)
    {
        if (data[0] == "Regenerate")
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            this.AddSoldierToArmy(data);
        }
    }

    private void AddSoldierToArmy(IList<string> data)
    {
        var type = data[0];
        var name = data[1];
        var age = int.Parse(data[2]);
        var experience = double.Parse(data[3]);
        var endurance = double.Parse(data[4]);

        var soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void MissionCommand(IList<string> data)
    {
        var difficultyLevel = data[0];
        var scoreToComplete = double.Parse(data[1]);
        var mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.WriteLine(this.missionController.PerformMission(mission).Trim());
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        var result = new StringBuilder();

        result.AppendLine(string.Format(OutputMessages.Results));
        result.AppendLine(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        result.AppendLine(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));
        result.AppendLine(string.Format(OutputMessages.Soldiers));

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            result.AppendLine(soldier.ToString());
        }

        this.writer.WriteLine(result.ToString().Trim());
    }
}