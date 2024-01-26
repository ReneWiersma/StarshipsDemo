using Construction;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class StarshipController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var starships = AppBuilder.StarshipRepo.GetAll();

            return Ok(starships.ToDto());
        }

        [HttpGet("AddModule")]
        public IActionResult AddModule(Guid starShipdId, int moduleTypeId)
        {
            var result = AppBuilder.AddModule(starShipdId, moduleTypeId);

            return ToActionResult(result);
        }

        private IActionResult ToActionResult(AddModuleResult result) => result switch
        {
            AddModuleResult.ModuleTooHeavy => BadRequest("Module too heavy"),
            AddModuleResult.StarshipNotFound => NotFound("Starship not found"),
            AddModuleResult.ModuleNotFound => NotFound("Module not found"),
            _ => Ok(),
        };
    }
}
