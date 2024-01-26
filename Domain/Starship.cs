namespace Domain
{
    public interface IStarshipRepo
    {
        Starship? Get(Guid starShipdId);
        IEnumerable<Starship> GetAll();
        void Save(Starship starship);
        void Delete(Starship starship);
    }

    public interface IModuleTypeRepo
    {
        ModuleType? Get(int moduleTypeId);
        IEnumerable<ModuleType> GetAll();
    }

    public sealed record StarshipType(int Id, string Name, int MaxWeight);

    public sealed record ModuleType(int Id, string Name, int Weight);

    public sealed record Starship(Guid Id, string Name, StarshipType Type, List<ModuleType> Modules)
    {
        public AddModuleResult AddModule(ModuleType moduleType)
        {
            if (Modules.Sum(m => m.Weight) + moduleType.Weight > Type.MaxWeight)
                return AddModuleResult.ModuleTooHeavy;

            Modules.Add(moduleType);

            return AddModuleResult.Success;
        }
    }

    public enum AddModuleResult
    {
        Success,
        StarshipNotFound,
        ModuleTooHeavy,
        ModuleNotFound
    }
}
