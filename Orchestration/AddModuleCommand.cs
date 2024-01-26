using Domain;

namespace Orchestration
{
    public sealed class AddModuleCommand(IStarshipRepo starshipRepo, IModuleTypeRepo moduleTypeRepo)
    {
        public AddModuleResult Execute(Guid starShipdId, int moduleTypeId)
        {
            var starship = starshipRepo.Get(starShipdId);
            
            if (starship == default)
                return AddModuleResult.StarshipNotFound;

            var moduleType = moduleTypeRepo.Get(moduleTypeId);

            if (moduleType == default)
                return AddModuleResult.ModuleNotFound;

            var result = starship.AddModule(moduleType);

            if (result == AddModuleResult.Success)
                starshipRepo.Save(starship);

            return result;
        }
    }
}
