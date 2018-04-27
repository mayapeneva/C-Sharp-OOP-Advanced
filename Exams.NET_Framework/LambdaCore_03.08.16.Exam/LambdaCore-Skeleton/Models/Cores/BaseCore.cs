using LambdaCore_Skeleton.Enums;
using LambdaCore_Skeleton.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LambdaCore_Skeleton.Models.Cores
{
    public abstract class BaseCore : ICore
    {
        private const string NormalStatus = "NORMAL";
        private const string CriticalStatus = "CRITICAL";

        private int durability;
        private readonly List<IFragment> fragments;

        protected BaseCore(CoreType coreType, int durability)
        {
            this.CoreType = coreType;
            this.durability = durability;
            this.fragments = new List<IFragment>();
        }

        public CoreType CoreType { get; }

        public virtual int Durability => this.durability;

        public List<IFragment> Fragments => this.fragments;

        public void AttachFragment(IFragment fragment)
        {
            this.fragments.Add(fragment);
        }

        public string DetachFragment()
        {
            var fragmentName = this.fragments[this.fragments.Count - 1].Name;
            this.fragments.RemoveAt(this.fragments.Count - 1);
            return fragmentName;
        }

        public string GetStatus()
        {
            var result = NormalStatus;
            var totalPressure = this.fragments.Sum(f => f.PressureAffection);
            if (totalPressure > 0)
            {
                this.durability -= totalPressure;
                result = CriticalStatus;
            }

            if (this.durability < 0)
            {
                this.durability = 0;
            }

            return result;
        }
    }
}