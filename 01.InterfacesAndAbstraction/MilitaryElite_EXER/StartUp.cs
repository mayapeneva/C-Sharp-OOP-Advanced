using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite_EXER.Classes;
using MilitaryElite_EXER.Interfaces;

namespace MilitaryElite_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var soldiers = new List<ISoldier>();
            while (input[0] != "End")
            {
                var id = int.Parse(input[1]);
                var firstName = input[2];
                var lastName = input[3];

                switch (input[0])
                {
                    case "Private":
                        soldiers.Add(new Private(id, firstName, lastName, double.Parse(input[4])));
                        break;

                    case "LeutenantGeneral":
                        var privates = new List<ISoldier>();
                        for (int i = 5; i < input.Length; i++)
                        {
                            privates.Add(soldiers.First(s => s.Id == int.Parse(input[i])));
                        }
                        var leutenantGeneral = new LeutenantGeneral(id, firstName, lastName, double.Parse(input[4]), privates);
                        soldiers.Add(leutenantGeneral);
                        break;

                    case "Engineer":
                        if (input[5] == "Airforces" || input[5] == "Marines")
                        {
                            var engineer = new Engineer(id, firstName, lastName, double.Parse(input[4]), input[5]);
                            for (int j = 6; j < input.Length; j += 2)
                            {
                                var part = input[j];
                                var hours = int.Parse(input[j + 1]);
                                engineer.Repairs.Add(new Repair(part, hours));
                            }
                            soldiers.Add(engineer);
                        }
                        break;

                    case "Commando":
                        if (input[5] == "Airforces" || input[5] == "Marines")
                        {
                            var commando = new Commando(id, firstName, lastName, double.Parse(input[4]), input[5]);
                            for (int k = 6; k < input.Length; k += 2)
                            {
                                var missionName = input[k];
                                var state = input[k + 1];
                                if (state == "inProgress" || state == "Finished")
                                {
                                    commando.Missions.Add(new Mission(missionName, state));
                                }
                            }
                            soldiers.Add(commando);
                        }
                        break;

                    case "Spy":
                        soldiers.Add(new Spy(id, firstName, lastName, int.Parse(input[4])));
                        break;
                }

                input = Console.ReadLine().Split();
            }

            soldiers.ForEach(s => Console.WriteLine(s.ToString()));
        }
    }
}