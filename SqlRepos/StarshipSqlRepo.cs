using Domain;

namespace SqlRepos
{
    public sealed class StarshipSqlRepo(string connectionString) : IStarshipRepo
    {
        private static IEnumerable<Starship> starships = new List<Starship>
        {
            new
            (
                Guid.NewGuid(), 
                "S.S. Enterprise", 
                new StarshipType(1, "Mothership", 1000),
                [
                    new(Id: 1, "Engine", Weight: 100),
                    new(Id: 2, "Shield", Weight: 200),
                    new(Id: 2, "Shield", Weight: 200),
                ]
            )
        };

        public void Delete(Starship starship) => starships = starships.Where(s => s.Id != starship.Id);

        public Starship? Get(Guid starShipdId) => starships.SingleOrDefault(s => s.Id == starShipdId);

        public IEnumerable<Starship> GetAll() => starships;

        public void Save(Starship starship)
        { 
            var existingStarship = starships.SingleOrDefault(s => s.Id == starship.Id);

            if (existingStarship == default)
                starships = starships.Append(starship);
            else
                starships = starships.Select(s => s.Id == starship.Id ? starship : s);
        }
    }
}
