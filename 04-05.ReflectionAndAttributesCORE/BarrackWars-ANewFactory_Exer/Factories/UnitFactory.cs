namespace _03BarracksFactory.Factories
{
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        private const string UnitNameSpace = "_03BarracksFactory.Models.";

        public IUnit CreateUnit(string unitType)
        {
            var classType = Type.GetType(UnitNameSpace + unitType);
            if (classType == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            return (IUnit)Activator.CreateInstance(classType);
        }
    }
}