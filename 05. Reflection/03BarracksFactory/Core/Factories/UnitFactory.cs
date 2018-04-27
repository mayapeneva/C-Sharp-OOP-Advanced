namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var classType = Type.GetType($"_03BarracksFactory.Models.Units.{unitType}");
            IUnit unit = (IUnit)Activator.CreateInstance(classType);
            return unit;
        }
    }
}