﻿using System;

public class Dragon : ITarget
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private Logger logger;

    public Dragon(string id, int hp, int reward, Logger logger)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.logger = logger;
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if (this.IsDead && !eventTriggered)
        {
            Console.WriteLine(THIS_DIED_EVENT, this);
            this.eventTriggered = true;
        }
    }

    public override string ToString()
    {
        return this.id;
    }
}