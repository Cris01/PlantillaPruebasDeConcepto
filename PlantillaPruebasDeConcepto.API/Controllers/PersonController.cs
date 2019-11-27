using Microsoft.AspNetCore.Mvc;
using PlantillaPruebasDeConcepto.Domain.Services;
using System.Threading.Tasks;

namespace PlantillaPruebasDeConcepto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _PersonService;

        public PersonController(PersonService personService)
        {
            _PersonService = personService;
        }
        [HttpGet]
        [Route("canVote")]
        public async Task<string> CanVote([FromQuery] int id)
        {
            return await _PersonService.VerifyIfPersonCanVote(id).ConfigureAwait(false);
        }
    }
}
