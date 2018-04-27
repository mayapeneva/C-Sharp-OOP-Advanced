using System.Collections.Generic;

public abstract class Mission : IMission
{
    private string name;
    private double enduranceRequired;
    private double scoreToComplete;
    private double wearLevelDecrement;

    protected Mission(string name, double enduranceRequired, double scoreToComplete)
    {
        this.name = name;
        this.enduranceRequired = enduranceRequired;
        this.scoreToComplete = scoreToComplete;
    }

    public string Name
    {
        get { return this.name; }
    }

    public double EnduranceRequired
    {
        get { return this.enduranceRequired; }
    }

    public double ScoreToComplete
    {
        get { return this.scoreToComplete; }
    }

    public ICollection<IAmmunition> MissionWeapons { get; set; }
    public int DecreasingMotivation { get; set; }
    public double DecreasingEndurance { get; set; }
    public string RequiredTeam { get; set; }
    public double MotivationNeeded { get; set; }
}