using StripsBL.Models;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Interfaces
{
    public interface IStripRepository
    {
        void AddAuteur(AuteurStrip auteurs);
        void RemoveAuteur(AuteurStrip auteurs);
        void UpdateStrip(Strip strip); 
        Strip GetStrip(int id);
        bool ExistsStrip(int id);
    }
}
