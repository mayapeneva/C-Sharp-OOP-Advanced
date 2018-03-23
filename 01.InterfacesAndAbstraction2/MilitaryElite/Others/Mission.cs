public class Mission
{
    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName { get; }
    public string State { get; }

    public void CompleteMission()
    {
    }

    public override string ToString()
    {
        return $"  Code Name: {this.CodeName} State: {this.State}";
    }
}