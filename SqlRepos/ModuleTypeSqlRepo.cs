using Domain;

namespace SqlRepos
{
    public sealed class ModuleTypeSqlRepo(string connectionString) : IModuleTypeRepo
    {
        private static IEnumerable<ModuleType> moduleTypes = new List<ModuleType>
        { 
            new(Id: 1, "Engine", Weight: 100),
            new(Id: 2, "Shield", Weight: 200),
            new(Id: 3, "Tractor beam", Weight: 150),
        };

        public ModuleType? Get(int moduleTypeId) => moduleTypes.SingleOrDefault(m => m.Id == moduleTypeId);

        public IEnumerable<ModuleType> GetAll() => moduleTypes;
    }
}
