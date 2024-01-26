using Construction;
using Domain;

namespace ReposTests
{
    public sealed class StarshipRepoTests
    {
        private static Starship CreateStarship() => new
        (
            Guid.NewGuid(),
            "SomeStarship",
            new StarshipType(1, "Mothership", 1000),
            Modules: []
        );

        [Test]
        public void GetAllWorks()
        {
            Assert.That(AppBuilder.StarshipRepo.GetAll(), Is.Not.Null);
        }

        [Test]
        public void GetWorks()
        {
            var starship = CreateStarship();

            AppBuilder.StarshipRepo.Save(starship);

            Assert.That(AppBuilder.StarshipRepo.Get(starship.Id), Is.EqualTo(starship));
        }

        [Test]
        public void SaveWorks()
        {
            var starship = CreateStarship();

            AppBuilder.StarshipRepo.Save(starship);

            var module = new ModuleType(1, "Engine", 100);

            starship.AddModule(module);

            AppBuilder.StarshipRepo.Save(starship);

            Assert.That(AppBuilder.StarshipRepo.Get(starship.Id)?.Modules.First(), Is.EqualTo(module));
        }

        [Test]
        public void DeleteWorks()
        {
            var starship = CreateStarship();

            AppBuilder.StarshipRepo.Save(starship);
            AppBuilder.StarshipRepo.Delete(starship);

            Assert.That(AppBuilder.StarshipRepo.Get(starship.Id), Is.Null);
        }
    }
}