using StripDL;
using StripsBL.Models;

namespace StripsDL
{
    public class DatabaseInitializer
    {
        private readonly StripsContext _context;

        public DatabaseInitializer(StripsContext context)
        {
            _context = context;
        }

        public void InitialiseerDatabank(string path)
        {
            if (_context.Strip.Any())
            {
                Console.WriteLine("Database is al geinitialiseerd.");
                return;
            }
            Dictionary<string, Uitgeverij> uitgeverijDict = new Dictionary<string, Uitgeverij>();
            Dictionary<string, Reeks> reeksDict = new Dictionary<string, Reeks>();
            Dictionary<string, Auteur> auteurDict = new Dictionary<string, Auteur>();
            HashSet<Strip> stripSet = new HashSet<Strip>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string titel;
                int nr;
                string reeks;
                string uitgeverij;
                string[] auteurs;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] ss = line.Split(';').Select(x => x.Trim()).ToArray();
                    titel = ss[0];
                    nr = int.Parse(ss[1]);
                    reeks = ss[2];
                    auteurs = ss[3].Split(",").Select(x => x.Trim()).ToArray();
                    uitgeverij = ss[4];

                    if (!reeksDict.ContainsKey(reeks)) reeksDict.Add(reeks, new Reeks(reeks));
                    if (!uitgeverijDict.ContainsKey(uitgeverij)) uitgeverijDict.Add(uitgeverij, new Uitgeverij(uitgeverij));
                    foreach (string auteur in auteurs)
                    {
                        if (!auteurDict.ContainsKey(auteur)) auteurDict.Add(auteur, new Auteur(auteur));
                    }

                    Strip s = new Strip(nr, titel)
                    {
                        Reeks = reeksDict[reeks],
                        Uitgeverij = uitgeverijDict[uitgeverij]
                    };

                    foreach (string auteur in auteurs)
                    {
                        s.VoegAuteurToe(auteurDict[auteur]);
                    }

                    stripSet.Add(s);
                }
            }

            _context.Strip.AddRange(stripSet);
            _context.SaveChanges();
            Console.WriteLine("Einde DB initialisatie");
        }
    }
}
