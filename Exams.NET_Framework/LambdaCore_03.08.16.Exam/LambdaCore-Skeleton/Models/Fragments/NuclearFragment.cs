using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Models.Fragments
{
    public class NuclearFragment : BaseFragment
    {
        private readonly int pressureAffection;

        public NuclearFragment(string name, FragmentType fragmentType, int pressureAffection) : base(name, fragmentType)
        {
            this.pressureAffection = pressureAffection;
        }

        public override int PressureAffection => this.pressureAffection * 2;
    }
}