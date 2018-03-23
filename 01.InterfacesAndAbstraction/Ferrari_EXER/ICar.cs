namespace Ferrari_EXER
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }

        string UseBrakes();

        string PushTheGas();
    }
}