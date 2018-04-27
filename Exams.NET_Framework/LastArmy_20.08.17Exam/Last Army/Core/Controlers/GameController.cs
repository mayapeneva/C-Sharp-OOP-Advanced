using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

public class GameController
{
    private const string MethodPrefix = "Add";

    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionControllerField;

    public GameController()
    {
        this.Army = new Army();
        this.WearHouse = new WareHouse();
        this.MissionControllerField = new MissionController(this.army, this.wareHouse);
    }

    public IArmy Army
    {
        get { return this.army; }
        set { army = value; }
    }

    public IWareHouse WearHouse
    {
        get { return this.wareHouse; }
        set { this.wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return this.missionControllerField; }
        set { this.missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (data[1].Equals("Regenerate"))
        {
        }
        else
        {
            var methodName = MethodPrefix + data[0];
            var methodTypeInfo = this.GetType().GetMethods().FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

            var nonParsedParams = default(string[]);
            if (methodTypeInfo != null)
            {
                var methodsParams = methodTypeInfo.GetParameters();

                object[] parsedParams = ParseParams(methodsParams, nonParsedParams);

                methodTypeInfo.Invoke(this, BindingFlags.Instance | BindingFlags.NonPublic, null, parsedParams, CultureInfo.InvariantCulture);
            }
        }
    }

    private object[] ParseParams(ParameterInfo[] methodsParams, string[] nonParsedParams)
    {
        var parsedParams = new object[methodsParams.Length];
        for (int i = 0; i < methodsParams.Length; i++)
        {
            parsedParams[i] = Convert.ChangeType(nonParsedParams[i], methodsParams[i].ParameterType);
        }

        return parsedParams;
    }

    //public string RequestResult()
    //{
    //    return Output.GiveOutput(result, army, wearHouse, this.MissionControllerField.MissionQueue.Count);
    //}

    private void AddMission(string typeName, int scoreToComplete)
    {
        var missionTypeInfo = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(m => m.Name.Equals(typeName));
        var mission = (IMission)Activator.CreateInstance(missionTypeInfo, new object[] { typeName, scoreToComplete });

        this.missionControllerField.PerformMission(mission);
    }

    private void AddWareHouse(string typeName, int count)
    {
        this.wareHouse.AddAmmunition(typeName, count);
    }

    private void AddSoldier(string typeName, string name, int age, double experience, double endurance)
    {
        var soldierTypeInfo = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(s => s.Name.Equals(typeName));
        var soldier = (ISoldier)Activator.CreateInstance(soldierTypeInfo, new object[] { name, age, experience, endurance });

        if (!this.CheckIfSoldierCanJoinTeam(soldier))
        {
            throw new ArgumentException($"There is no weapon for {typeName} {name}!");
        }

        this.army.AddSoldier(soldier, typeName);
    }

    private bool CheckIfSoldierCanJoinTeam(ISoldier solder)
    {
        foreach (var weaponAllowed in solder.WeaponsAllowed)
        {
            if (!this.WearHouse.Ammunitions.ContainsKey(weaponAllowed))
            {
                return false;
            }
        }

        return true;
    }
}