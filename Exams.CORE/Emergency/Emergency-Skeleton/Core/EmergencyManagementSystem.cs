using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EmergencyManagementSystem
{
    private readonly EmergencyRegister register;
    private readonly EmergencyFactory emergencyFactory;
    private readonly CenterFactory centerFactory;

    private string[] args;
    private Dictionary<string, List<IEmergencyCenter>> emergencyCenters;

    public EmergencyManagementSystem(EmergencyRegister register, EmergencyFactory emergencyFactory, CenterFactory centerFactory)
    {
        this.register = register;
        this.emergencyFactory = emergencyFactory;
        this.centerFactory = centerFactory;

        this.InitialiseEmergencyCenters();
    }

    public string FindTheRightMethod(string[] arguments)
    {
        var methodName = arguments[0];
        this.args = arguments.Skip(1).ToArray();

        var classType = typeof(EmergencyManagementSystem);
        var method = classType.GetMethods().First(m => m.Name.Equals(methodName)).Invoke(this, new object[0]);

        return method.ToString();
    }

    private void InitialiseEmergencyCenters()
    {
        this.emergencyCenters = new Dictionary<string, List<IEmergencyCenter>>();
        this.emergencyCenters["Fire"] = new List<IEmergencyCenter>();
        this.emergencyCenters["Medical"] = new List<IEmergencyCenter>();
        this.emergencyCenters["Police"] = new List<IEmergencyCenter>();
    }

    public string RegisterPropertyEmergency()
    {
        var description = args[0];
        var level = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), args[1]);
        var registrationTime = new RegistrationTime(args[2]);
        var damage = int.Parse(args[3]);
        var data = new object[] { description, level, registrationTime, damage };
        var emergency = this.emergencyFactory.CreateEmergency("PublicPropertyEmergency", data);
        this.register.EnqueueEmergency(emergency);

        return string.Format(OutputMessages.RegisterPropertyEmergency, level, registrationTime);
    }

    public string RegisterHealthEmergency()
    {
        var description = this.args[0];
        var level = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.args[1]);
        var registrationTime = new RegistrationTime(this.args[2]);
        var casualties = int.Parse(this.args[3]);
        var data = new object[] { description, level, registrationTime, casualties };
        var emergency = this.emergencyFactory.CreateEmergency("PublicHealthEmergency", data);
        this.register.EnqueueEmergency(emergency);

        return string.Format(OutputMessages.RegisterHealthEmergency, level, registrationTime);
    }

    public string RegisterOrderEmergency()
    {
        var description = this.args[0];
        var level = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.args[1]);
        var registrationTime = new RegistrationTime(this.args[2]);
        var status = this.args[3];
        var data = new object[] { description, level, registrationTime, status };
        var emergency = this.emergencyFactory.CreateEmergency("PublicOrderEmergency", data);
        this.register.EnqueueEmergency(emergency);

        return string.Format(OutputMessages.RegisterOrderEmergency, level, registrationTime);
    }

    public string RegisterFireServiceCenter()
    {
        var name = this.args[0];
        var amountOfEmergencies = int.Parse(this.args[1]);
        var data = new object[] { name, amountOfEmergencies };
        var center = this.centerFactory.CreateCenter("FireServiceCenter", data);

        this.emergencyCenters["Fire"].Add(center);

        return string.Format(OutputMessages.RegisterFireCenter, name);
    }

    public string RegisterMedicalServiceCenter()
    {
        var name = this.args[0];
        var amountOfEmergencies = int.Parse(this.args[1]);
        var data = new object[] { name, amountOfEmergencies };
        var center = this.centerFactory.CreateCenter("MedicalServiceCenter", data);

        this.emergencyCenters["Medical"].Add(center);

        return string.Format(OutputMessages.RegisterMedicalCenter, name);
    }

    public string RegisterPoliceServiceCenter()
    {
        var name = this.args[0];
        var amountOfEmergencies = int.Parse(this.args[1]);
        var data = new object[] { name, amountOfEmergencies };
        var center = this.centerFactory.CreateCenter("PoliceServiceCenter", data);

        this.emergencyCenters["Police"].Add(center);

        return string.Format(OutputMessages.RegisterPoliceCenter, name);
    }

    public string ProcessEmergencies()
    {
        var emergenciesNotProcessed = 0;

        var emergencyString = this.args[0];
        var emergencyType = "Public" + emergencyString + "Emergency";
        var classType = Type.GetType(emergencyType);
        for (int i = 0; i < this.register.Count; i++)
        {
            var emergency = this.register.DequeueEmergency();
            if (emergency.GetType() == classType)
            {
                string centerType;
                if (emergencyType.Contains("Property"))
                {
                    centerType = "Fire";
                }
                else if (emergencyType.Contains("Health"))
                {
                    centerType = "Medical";
                }
                else
                {
                    centerType = "Police";
                }

                if (this.emergencyCenters[centerType].Any(c => !c.isForRetirement))
                {
                    this.emergencyCenters[centerType].First(c => !c.isForRetirement).Emergencies.Add(emergency);
                }
                else
                {
                    this.register.EnqueueEmergency(emergency);
                    emergenciesNotProcessed++;
                }
            }
            else
            {
                this.register.EnqueueEmergency(emergency);
            }
        }

        if (emergenciesNotProcessed == 0)
        {
            return string.Format(OutputMessages.SuccessfulRespond, emergencyString);
        }

        return string.Format(OutputMessages.EmergenciesLeft, emergencyString, emergenciesNotProcessed);
    }

    public string EmergencyReport()
    {
        var result = new StringBuilder();
        result.AppendLine("PRRM Services Live Statistics");
        result.AppendLine($"Fire Service Centers: {this.emergencyCenters["Fire"].Count}");
        result.AppendLine($"Medical Service Centers: {this.emergencyCenters["Medical"].Count}");
        result.AppendLine($"Police Service Centers: {this.emergencyCenters["Police"].Count}");
        result.AppendLine($"Total Processed Emergencies: {this.emergencyCenters.Values.Sum(x => x.Sum(c => c.Emergencies.Count))}");
        result.AppendLine($"Currently Registered Emergencies: {this.register.Count}");

        var totalDamage = 0;
        foreach (var center in this.emergencyCenters["Fire"])
        {
            totalDamage += center.Emergencies.Sum(e => (e as PublicPropertyEmergency).Damage);
        }
        result.AppendLine($"Total Property Damage Fixed: {totalDamage}");

        var totalCasualties = 0;
        foreach (var center in this.emergencyCenters["Medical"])
        {
            totalCasualties += center.Emergencies.Sum(e => (e as PublicHealthEmergency).Casualties);
        }
        result.AppendLine($"Total Health Casualties Saved: {totalCasualties}");

        var totalSpecialCases = 0;
        foreach (var center in this.emergencyCenters["Police"])
        {
            totalSpecialCases += center.Emergencies.Count(e => (e as PublicOrderEmergency).Status.Equals("Special"));
        }
        result.AppendLine($"Total Special Cases Processed: {totalSpecialCases}");

        return result.ToString().Trim();
    }
}