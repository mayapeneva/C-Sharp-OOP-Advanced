using LambdaCore_Skeleton.Enums;
using System.Collections.Generic;

namespace LambdaCore_Skeleton.Interfaces
{
    public interface ICore
    {
        CoreType CoreType { get; }
        int Durability { get; }
        List<IFragment> Fragments { get; }

        void AttachFragment(IFragment fragment);

        string DetachFragment();

        string GetStatus();
    }
}