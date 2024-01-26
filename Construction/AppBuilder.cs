using Domain;
using Orchestration;
using SqlRepos;

namespace Construction
{
    public static class AppBuilder
    {
        private static readonly string ConnectionString = "SomeLongConnectionString...";

        public static StarshipSqlRepo StarshipRepo => new(ConnectionString);

        public static ModuleTypeSqlRepo ModuleTypeSqlRepo => new(ConnectionString);

        public static AddModuleCommand AddModuleCommand => new(StarshipRepo, ModuleTypeSqlRepo);

        public static AddModuleResult AddModule(Guid starShipdId, int moduleTypeId) => 
            AddModuleCommand.Execute(starShipdId, moduleTypeId);
    }
}
