public class BuyersFactory
{
    public IBuyer CreateBuyer(params string[] input)
    {
        if (input.Length > 3)
        {
            var name = input[0];
            var age = int.Parse(input[1]);
            var id = input[2];
            var birthdate = input[3];

            return new Citizen(name, age, id, birthdate);
        }
        else
        {
            var name = input[0];
            var age = int.Parse(input[1]);
            var group = input[2];

            return new Rebel(name, age, group);
        }
    }
}