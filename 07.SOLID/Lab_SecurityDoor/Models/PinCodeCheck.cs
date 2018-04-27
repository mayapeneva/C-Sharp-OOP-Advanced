public class PinCodeCheck : SecurityCheck
{
    private readonly ISecurityUI securityUI;

    public PinCodeCheck(ISecurityUI securityUI)
    {
        this.securityUI = securityUI;
    }

    private bool IsValid(int pin)
    {
        return true;
    }

    public override bool ValidateUser()
    {
        int pin = this.securityUI.RequestPinCode();
        if (this.IsValid(pin))
        {
            return true;
        }

        return false;
    }
}