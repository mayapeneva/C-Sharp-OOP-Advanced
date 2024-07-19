using System;

public delegate void NameChangeEventHandler(object sender, EventArgs args);

public class Dispatcher
{
    public string Name { get; }
}

public class Handler
{
}