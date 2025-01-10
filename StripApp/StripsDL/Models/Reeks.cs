using System.Text.Json.Serialization;

namespace StripsBL.Models
{
    public class Reeks
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Strip> Strips { get; set; } = new List<Strip>();

        public Reeks(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new ArgumentException("De naam van een reeks mag niet leeg zijn.");
            }
            Naam = naam;
        }
    }
}
