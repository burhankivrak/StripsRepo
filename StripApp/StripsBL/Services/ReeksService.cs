using Microsoft.EntityFrameworkCore;
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
    public class ReeksService : IReeksRepository
    {
        private readonly StripsContext ctx;

        public ReeksService(StripsContext context)
        {
            ctx = context;
        }

        public Reeks GetReeks(int id)
        {
            var reeks = ctx.Reeks.Include(r => r.Strips).FirstOrDefault(r => r.Id == id);

            if (reeks == null)
            {
                throw new DomeinException("Reeks bestaat niet");
            }

            return reeks;
        }
    }
}
