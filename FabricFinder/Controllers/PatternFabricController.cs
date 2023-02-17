using FabricFinder.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FabricFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatternFabricController : ControllerBase
    {
        // GET: api/<PatternFabricController>
        private IPatternFabricRepository _patternFabricRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public PatternFabricController(IPatternFabricRepository patternfabricRepository, IUserProfileRepository userProfileRepository)
        {
            _patternFabricRepository = patternfabricRepository;
            _userProfileRepository = userProfileRepository;

        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var patternFabric = _patternFabricRepository.GetByUserId(id);
            if (patternFabric == null)
            {
                return NotFound();
            }
            return Ok(patternFabric);
        }
    }
}
