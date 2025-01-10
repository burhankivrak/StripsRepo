using StripsBL.Models;
using System.Text.Json.Serialization;

namespace StripREST.DTO
{
    public class ReeksDTO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Url { get; set; }
        public List<SimpleStripDTO> Strips { get; set; } = new List<SimpleStripDTO>();
    }
}
