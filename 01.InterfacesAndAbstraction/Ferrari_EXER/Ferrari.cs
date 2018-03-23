namespace Ferrari_EXER
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Model { get; }
        public string Driver { get; }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public string PushTheGas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGas()}/{this.Driver}";
        }
    }
}