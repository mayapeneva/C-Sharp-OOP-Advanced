public class InhabitantFactory
{
    public IInhabitant CreateInhabitant(params string[] input)
    {
        if (input.Length > 2)
        {
            var name = input[0];
            var age = int.Parse(input[1]);
            var id = input[2];

            return new Citizen(name, age, id);
        }
        else
        {
            var mode = input[0];
            var id = input[1];

            return new Robot(mode, id);
        }
    }
}