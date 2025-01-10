using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StripsBL.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public ICollection<Strip> Strips { get; set; } = new List<Strip>();
        public Auteur() { }

        public Auteur(string naam)
        {
            Naam = naam;
        }

        public Auteur(string naam, string? email)
        {
            Naam = naam;
            Email = email;
        }
    }
}
