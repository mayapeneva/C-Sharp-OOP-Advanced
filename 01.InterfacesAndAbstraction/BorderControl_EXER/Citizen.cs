namespace BorderControl_EXER
{
    public class Citizen : IInteligent, IAnimal, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; }
        public string Birthdate { get; }
        public int Age { get; }
        public string Id { get; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}