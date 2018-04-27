using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Models.Fragments
{
    public class CoolingFragment : BaseFragment
    {
        private readonly int pressureAffection;

        public CoolingFragment(string name, FragmentType fragmentType, int pressureAffection) : base(name, fragmentType)
        {
            this.pressureAffection = pressureAffection;
        }

        public override int PressureAffection => -this.pressureAffection * 3;
    }
}