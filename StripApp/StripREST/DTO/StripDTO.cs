namespace StripREST.DTO
{
    public class StripDTO
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Nr { get; set; }
        public string Url { get; set; }
        public string Uitgeverij { get; set; }
        public string UitgeverijUrl { get; set; }
        public string Reeks { get; set; }
        public string ReeksUrl { get; set; }

        public List<AuteurDTO> Auteurs { get; set; } = new List<AuteurDTO>();
    }
}
