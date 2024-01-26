using Domain;

namespace RestService.Controllers
{

    public record StarshipDto(Guid Id, string Name, string TypeName, IEnumerable<ModuleDto> Modules);

    public record ModuleDto(string TypeName);

    public static class Converters
    {
        public static IEnumerable<StarshipDto> ToDto(this IEnumerable<Starship> starships) =>
            starships.Select(s => s.ToDto());

        public static StarshipDto ToDto(this Starship starship) =>
            new(starship.Id, starship.Name, starship.Type.Name, starship.Modules.Select(m => m.ToDto()));

        public static ModuleDto ToDto(this ModuleType module) =>
            new(module.Name);
    }
}
