using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Interfaces
{
    public interface IFragment
    {
        string Name { get; }

        FragmentType FragmentType { get; }

        int PressureAffection { get; }
    }
}