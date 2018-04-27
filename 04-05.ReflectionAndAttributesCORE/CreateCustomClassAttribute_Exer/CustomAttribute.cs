using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class)]
public class CustomAttribute : Attribute
{
    public string Author { get; set; }
    public int Revision { get; set; }
    public string Description { get; set; }
    public List<string> Reviewers { get; set; }
}