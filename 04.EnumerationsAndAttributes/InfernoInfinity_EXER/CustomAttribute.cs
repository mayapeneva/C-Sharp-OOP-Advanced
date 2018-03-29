using System;
using System.Collections.Generic;

namespace InfernoInfinity_EXER
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        private readonly string author;
        private readonly int revision;
        private readonly string description;
        private readonly List<string> reviewers;

        public CustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.author = author;
            this.revision = revision;
            this.description = description;
            this.reviewers = new List<string>(reviewers);
        }

        public string Print(string command)
        {
            switch (command)
            {
                case "Author":
                    return $"Author: {this.author}";

                case "Revision":
                    return $"Revision: {this.revision}";

                case "Description":
                    return $"Class description: {this.description}";

                case "Reviewers":
                    return $"Reviewers: {string.Join(", ", this.reviewers)}";
            }

            return string.Empty;
        }
    }
}