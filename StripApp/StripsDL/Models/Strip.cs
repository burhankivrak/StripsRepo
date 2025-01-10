using System.Text.Json.Serialization;

namespace StripsBL.Models
{
    public class Strip
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
        public Uitgeverij Uitgeverij { get; set; }
        
        public Reeks Reeks { get; set; }
        public int Nr { get; set; }

        public Strip() {}
        public Strip(int nr, string titel)
        {
            Nr = nr;
            Titel = titel;
        }

        public Strip(int nr, string titel,Uitgeverij uitgeverij, Reeks reeks)
        {
            Nr = nr;
            Titel = titel;
            Uitgeverij = uitgeverij;
            Reeks = reeks;
        }

        public void VoegAuteurToe(Auteur auteur)
        {
            Auteurs.Add(auteur);
        }
    }
}
