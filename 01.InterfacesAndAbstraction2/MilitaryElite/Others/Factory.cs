using System.Collections.Generic;
using System.Linq;

public class Factory
{
    private readonly List<Private> privates = new List<Private>();

    public ISoldier CreateSoldier(params string[] input)
    {
        var id = input[1];
        var firstName = input[2];
        var lastName = input[3];
        switch (input[0])
        {
            case "Private":
                var salary = double.Parse(input[4]);
                var privateSoldier = new Private(id, firstName, lastName, salary);
                this.privates.Add(privateSoldier);
                return privateSoldier;

            case "LeutenantGeneral":
                salary = double.Parse(input[4]);
                var privates = new List<Private>();
                for (int i = 5; i < input.Length; i++)
                {
                    privates.Add(this.privates.First(s => s.Id.Equals(input[i])));
                }

                return new LeutenantGeneral(id, firstName, lastName, salary, privates);

            case "Engineer":
                salary = double.Parse(input[4]);
                var corps = input[5];
                if (!corps.Equals("Airforces") && !corps.Equals("Marines"))
                {
                    return null;
                }

                var repairs = new List<Repair>();
                for (int i = 6; i < input.Length; i += 2)
                {
                    repairs.Add(new Repair(input[i], int.Parse(input[i + 1])));
                }

                return new Engineer(id, firstName, lastName, salary, corps, repairs);

            case "Commando":
                salary = double.Parse(input[4]);
                corps = input[5];
                if (!corps.Equals("Airforces") && !corps.Equals("Marines"))
                {
                    return null;
                }

                var missions = new List<Mission>();
                for (int i = 6; i < input.Length; i += 2)
                {
                    var state = input[i + 1];
                    if (state == "inProgress" || state == "Finished")
                    {
                        missions.Add(new Mission(input[i], state));
                    }
                }

                return new Commando(id, firstName, lastName, salary, corps, missions);

            case "Spy":
                var codeNumber = int.Parse(input[4]);
                return new Spy(id, firstName, lastName, codeNumber);
        }

        return null;
    }
}