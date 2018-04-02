public class InhabitantFactory
{
    public IBeing CreateBeing(params string[] input)
    {
        if (input[0] == "Citizen")
        {
            var name = input[1];
            var age = int.Parse(input[2]);
            var id = input[3];
            var birthdate = input[4];

            return new Citizen(name, age, id, birthdate);
        }

        if (input[0] == "Pet")
        {
            var name = input[1];
            var birthdate = input[2];

            return new Pet(name, birthdate);
        }

        return null;
    }
}