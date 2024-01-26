using Domain;

namespace DomainTests
{
    public sealed class StarshipTests
    {
        private static ModuleType ModuleTypeWithWeight(int weight) => new(Id: 1, "Engine", Weight: weight);

        private static StarshipType StarshipTypeWithWeight(int weight) => new(1, "Mothership", MaxWeight: weight);

        [Test]
        public void AddModuleWithinMaxWeight()
        {
            var starship = new Starship
            (
                Guid.NewGuid(), 
                "SomeStarship", 
                StarshipTypeWithWeight(1000), 
                Modules: []
            );

            Assert.That(starship.AddModule(ModuleTypeWithWeight(1000)), Is.EqualTo(AddModuleResult.Success));
        }

        [Test]
        public void AddModuleExceedingMaxWeight()
        {
            var starship = new Starship
            (
                Guid.NewGuid(),
                "SomeStarship",
                StarshipTypeWithWeight(1000),
                Modules: []
            );

            Assert.That(starship.AddModule(ModuleTypeWithWeight(1001)), Is.EqualTo(AddModuleResult.ModuleTooHeavy));
        }
    }
}