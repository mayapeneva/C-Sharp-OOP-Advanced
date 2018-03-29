using System;

namespace CardsGame_EXER
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }
    }
}