﻿public class Gun : Ammunition
{
    private const double DefaultWeight = 1.4;

    public Gun(string name)
        : base(name, DefaultWeight)
    {
    }
}