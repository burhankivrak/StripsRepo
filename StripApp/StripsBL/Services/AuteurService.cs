using StripDL;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;

namespace StripsBL.Services
{
    public class AuteurService : IAuteurRepository
    {
        private readonly StripsContext ctx;

        public AuteurService(StripsContext context)
        {
            ctx = context;
        }

        public void UpdateAuteur(Auteur auteur)
        {
            var bestaandeAuteur = ctx.Auteur.FirstOrDefault(a => a.Id == auteur.Id);

            if (bestaandeAuteur == null)
            {
                throw new DomeinException("Auteur bestaat niet");
            }

            ctx.Auteur.Entry(bestaandeAuteur).CurrentValues.SetValues(auteur); 
            ctx.SaveChanges();
        }
    }
}
