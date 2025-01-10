using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripREST.Mapper;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;
using StripsBL.Services;

namespace StripREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReeksController : ControllerBase
    {
        private readonly IReeksRepository _repo;

        public ReeksController(IReeksRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public ActionResult<Reeks> Get(int id)
        {
            try
            {
                var reeks = _repo.GetReeks(id);
                var reeksDTO = DTOMapper.MapToReeksDTO(reeks);
                return Ok(reeksDTO);
            }
            catch (DomeinException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
