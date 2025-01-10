using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Models
{
    //OK
    public class Uitgeverij
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string? Adres { get; set; }
        public Uitgeverij() {}
        public Uitgeverij(string naam)
        {
            Naam = naam;
        }
        public Uitgeverij(string naam, string? adres)
        {
            Naam = naam;
            Adres = adres;
        }

    }
}
