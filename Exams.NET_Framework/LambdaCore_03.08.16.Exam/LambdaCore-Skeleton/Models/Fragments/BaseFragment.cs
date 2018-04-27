using LambdaCore_Skeleton.Interfaces;

namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enums;

    public abstract class BaseFragment : IFragment
    {
        protected BaseFragment(string name, FragmentType fragmentType)
        {
            this.Name = name;
            this.FragmentType = fragmentType;
        }

        public string Name { get; }

        public FragmentType FragmentType { get; }

        public abstract int PressureAffection { get; }
    }
}