﻿namespace FestivalManager.Entities.Instruments
{
    using Contracts;
    using System;

    public abstract class Instrument : IInstrument
    {
        private double wear;
        private const int MaxWear = 100;

        protected Instrument()
        {
            this.Wear = MaxWear;
        }

        public double Wear
        {
            get => this.wear;
            private set => this.wear = Math.Min(Math.Max(value, 0), 100);
        }

        protected abstract int RepairAmount { get; }
        public bool IsBroken => this.Wear <= 0;

        public void Repair() => this.Wear += this.RepairAmount;

        public void WearDown() => this.Wear -= this.RepairAmount;

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

            return $"{this.GetType().Name} [{instrumentStatus}]";
        }
    }
}