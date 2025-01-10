using Microsoft.EntityFrameworkCore;
using StripDL;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;
using StripsDL.Models;

namespace StripsBL.Services
{
    public class StripService : IStripRepository
    {
        private readonly StripsContext ctx;

        public StripService(StripsContext context)
        {
            ctx = context;
        }

        public void AddAuteur(AuteurStrip x)
        {
            var bestaandeStrip = ctx.Strip.Include(s => s.Auteurs).FirstOrDefault(s => s.Id == x.StripId);
            if (bestaandeStrip == null)
            {
                throw new DomeinException("Strip bestaat niet");
            }
            var bestaandeAuteur = ctx.Auteur.Include(a => a.Strips).FirstOrDefault(a => a.Id == x.AuteurId);
            if (bestaandeAuteur == null)
            {
                throw new DomeinException("Auteur bestaat niet");
            }
            if (bestaandeStrip.Auteurs.Any(a => a.Id == x.AuteurId))
            {
                throw new DomeinException("Auteur is al toegevoegd aan deze strip");
            }
            var auteurStrip = new AuteurStrip
            {
                AuteurId = x.AuteurId,
                StripId = x.StripId
            };
            bestaandeStrip.VoegAuteurToe(bestaandeAuteur);
            bestaandeAuteur.Strips.Add(bestaandeStrip);
            ctx.AuteurStrip.Add(auteurStrip);
            ctx.SaveChanges();
        }

        public Strip GetStrip(int id)
        {
            var strip = ctx.Strip.FirstOrDefault(s => s.Id == id);

            if (strip == null)
            {
                throw new DomeinException("Strip bestaat niet");
            }

            return strip;
        }

        public void RemoveAuteur(AuteurStrip x)
        {
            var bestaandeStrip = ctx.Strip.Include(s => s.Auteurs).FirstOrDefault(s => s.Id == x.StripId);
            if (bestaandeStrip == null)
            {
                throw new DomeinException("Strip bestaat niet");
            }

            var bestaandeAuteur = ctx.Auteur.Include(a => a.Strips).FirstOrDefault(a => a.Id == x.AuteurId);
            if (bestaandeAuteur == null)
            {
                throw new DomeinException("Auteur is niet gekoppeld aan deze strip");
            }

            bestaandeStrip.Auteurs.Remove(bestaandeAuteur);
            ctx.SaveChanges();
        }

        public void UpdateStrip(Strip strip)
        {
            var bestaandeStrip = ctx.Strip.FirstOrDefault(u => u.Id == strip.Id);

            if (bestaandeStrip == null)
            {
                throw new DomeinException("Strip bestaat niet");
            }

            ctx.Strip.Entry(bestaandeStrip).CurrentValues.SetValues(strip); 
            ctx.SaveChanges();
        }

        public bool ExistsStrip(int id)
        {
            return ctx.Strip.Any(s => s.Id == id);
        }
    }
}
