using InfernoInfinity_EXER.Enums;

namespace InfernoInfinity_EXER.AllWeapons
{
    [Custom("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapons
    {
        public string Name { get; }
        public WeaponsStat Stats { get; }
    }
}