using StripDL;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Services
{
    public class UitgeverijService : IUitgeverijRepository
    {
        private readonly StripsContext ctx;

        public UitgeverijService(StripsContext context)
        {
            ctx = context;
        }

        public void UpdateUitgeverij(Uitgeverij uitgeverij)
        {
            var bestaandeUitgeverij = ctx.Uitgeverij.FirstOrDefault(u => u.Id == uitgeverij.Id);

            if (bestaandeUitgeverij == null)
            {
                throw new DomeinException("Uitgeverij bestaat niet");
            }
            ctx.Uitgeverij.Entry(bestaandeUitgeverij).CurrentValues.SetValues(uitgeverij);
            ctx.SaveChanges();
        }
    }
}
