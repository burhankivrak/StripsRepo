using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;

namespace StripREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UitgeverijController : ControllerBase
    {
        private readonly IUitgeverijRepository _repo;

        public UitgeverijController(IUitgeverijRepository repo)
        {
            _repo = repo;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Uitgeverij uitgeverij)
        {
            try
            {
                _repo.UpdateUitgeverij(uitgeverij);
                return NoContent();
            }
            catch (DomeinException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
