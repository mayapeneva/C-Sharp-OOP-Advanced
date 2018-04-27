using System;
using System.Collections.Generic;

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

    public string Author => $"Author: {this.author}";
    public string Revision => $"Revision: {this.revision}";
    public string Description => $"Class description: {this.description}";
    public string Reviewers => $"{string.Join(", ", this.reviewers)}";
}