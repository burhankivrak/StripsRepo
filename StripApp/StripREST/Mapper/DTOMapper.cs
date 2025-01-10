using StripREST.DTO;
using StripsBL.Models;

namespace StripREST.Mapper
{
    public static class DTOMapper
    {
        public static AuteurDTO MapToAuteurDTO(Auteur auteur)
        {
            return new AuteurDTO
            {
                Naam = auteur.Naam,
                Url = $"https://localhost:7148/api/Auteurs/{auteur.Id}"
            };
        }

        public static ReeksDTO MapToReeksDTO(Reeks reeks)
        {
            return new ReeksDTO
            {
                Id = reeks.Id,
                Naam = reeks.Naam,
                Url = $"https://localhost:7148/api/Reeks/{reeks.Id}",
                Strips = reeks.Strips.Select(strip => new SimpleStripDTO
                {
                    Nr = strip.Nr,
                    Titel = strip.Titel,
                    Url = $"https://localhost:7148/api/Strips/{strip.Id}" 
                }).ToList()
            };
        }

        public static UitgeverijDTO MapToUitgeverijDTO(Uitgeverij uitgeverij)
        {
            return new UitgeverijDTO
            {
                Naam = uitgeverij.Naam,
            };
        }

        public static StripDTO MapToStripDTO(Strip strip)
        {

            return new StripDTO
            {
                Url = $"https://localhost:7148/api/Strips/{strip.Id}",
                Titel = strip.Titel,
                Nr = strip.Nr,
                Reeks = strip.Reeks.Naam,
                ReeksUrl = $"https://localhost:7148/api/Reeks/{strip.Reeks.Id}",
                Uitgeverij = strip.Uitgeverij.Naam ,
                UitgeverijUrl = $"https://localhost:7148/api/Uitgeverij/{strip.Uitgeverij.Id}",
                Auteurs = strip.Auteurs.Select(auteur => MapToAuteurDTO(auteur)).ToList()
            };
        }
    }
}
