public class KeyCardCheck : SecurityCheck
{
    private readonly ISecurityUI securityUI;

    public KeyCardCheck(ISecurityUI securityUI)
    {
        this.securityUI = securityUI;
    }

    private bool IsValid(string code)
    {
        return true;
    }

    public override bool ValidateUser()
    {
        string code = this.securityUI.RequestKeyCard();
        if (this.IsValid(code))
        {
            return true;
        }

        return false;
    }
}