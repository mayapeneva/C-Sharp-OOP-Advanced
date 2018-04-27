using LambdaCore_Skeleton.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaCore_Skeleton.Core
{
    public class CoreManager : ICoreManager
    {
        private readonly Dictionary<char, ICore> powerPlant;
        private char selectedCoreName;
        private int nameIndex;

        public CoreManager()
        {
            this.powerPlant = new Dictionary<char, ICore>();
            this.nameIndex = 65;
        }

        public int TotalDurability
        {
            get { return this.powerPlant.Sum(c => c.Value.Durability); }
        }

        public int TotalFragmentsCount
        {
            get { return this.powerPlant.Sum(c => c.Value.Fragments.Count); }
        }

        public char AddCore(ICore core)
        {
            var coreName = (char)this.nameIndex;
            this.powerPlant.Add(coreName, core);
            this.nameIndex++;
            return coreName;
        }

        public bool RemoveCore(char coreName)
        {
            if (this.powerPlant.ContainsKey(coreName))
            {
                this.powerPlant.Remove(coreName);
                return true;
            }

            return false;
        }

        public bool SelectCore(char coreName)
        {
            if (this.powerPlant.ContainsKey(coreName))
            {
                this.selectedCoreName = coreName;
                return true;
            }

            return false;
        }

        public char AttachFragment(IFragment fragment)
        {
            if (this.selectedCoreName == default(char))
            {
                return default(char);
            }

            this.powerPlant[this.selectedCoreName].AttachFragment(fragment);
            return this.selectedCoreName;
        }

        public string[] DetachFragment()
        {
            if (this.selectedCoreName == default(char) || this.powerPlant[this.selectedCoreName].Fragments.Count == 0)
            {
                return default(string[]);
            }

            var result = new string[2];
            result[0] = this.selectedCoreName.ToString();
            result[1] = this.powerPlant[this.selectedCoreName].DetachFragment();
            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Lambda Core Power Plant Status:");
            result.AppendLine($"Total Durability: {this.TotalDurability}");
            result.AppendLine($"Total Cores: { this.powerPlant.Count }");
            result.AppendLine($"Total Fragments: {this.TotalFragmentsCount}");
            foreach (var core in this.powerPlant)
            {
                result.AppendLine($"Core {core.Key}:");
                result.AppendLine($"####Durability: {core.Value.Durability}");
                result.AppendLine($"####Status: {core.Value.GetStatus()}");
            }

            return result.ToString().Trim();
        }
    }
}