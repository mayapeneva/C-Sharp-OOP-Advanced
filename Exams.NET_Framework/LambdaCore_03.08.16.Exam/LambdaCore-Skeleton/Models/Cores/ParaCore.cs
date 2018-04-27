using LambdaCore_Skeleton.Enums;

namespace LambdaCore_Skeleton.Models.Cores
{
    public class ParaCore : BaseCore
    {
        public ParaCore(CoreType type, int durability)
            : base(type, durability)
        {
        }

        public override int Durability => this.Durability / 3;
    }
}