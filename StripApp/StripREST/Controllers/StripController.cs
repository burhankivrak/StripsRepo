using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripREST.Mapper;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;
using StripsBL.Services;
using StripsDL.Models;

namespace StripREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripController : ControllerBase
    {
        private readonly IStripRepository _repo;

        public StripController(IStripRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public ActionResult<Strip> Get(int id)
        {
            try
            {
                var strip = _repo.GetStrip(id);
                var stripDTO = DTOMapper.MapToStripDTO(strip);
                return Ok(stripDTO);
            }
            catch (DomeinException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Strip strip)
        {
            try
            {
                _repo.UpdateStrip(strip);
                return NoContent();
            }
            catch (DomeinException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("addAuteur")]
        public IActionResult AddAuteur([FromBody] AuteurStrip auteurS)
        {
            try
            {
                _repo.AddAuteur(auteurS);

                return Ok("Auteur succesvol toegevoegd");
            }
            catch (DomeinException ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete("removeAuteur)")]
        public IActionResult RemoveAuteur([FromBody] AuteurStrip auteurS)
        {
            try
            {
                _repo.RemoveAuteur(auteurS);

                return Ok("Auteur succesvol verwijderd");
            }
            catch (DomeinException ex)
            {
                return BadRequest(ex.Message);  
            }

        }
    }
}
