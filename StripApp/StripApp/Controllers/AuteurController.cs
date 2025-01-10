using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;

namespace StripREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly IAuteurRepository _repo;

        public AuteurController(IAuteurRepository repo)
        {
            _repo = repo;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Auteur auteur)
        {
            try
            {
                _repo.UpdateAuteur(auteur);
                return NoContent(); 
            }
            catch (DomeinException ex)
            {
                return NotFound(new { message = ex.Message }); 
            }
        }
    }
}
