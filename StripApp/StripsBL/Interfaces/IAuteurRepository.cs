using StripsBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Interfaces
{
    public interface IAuteurRepository
    {
        void UpdateAuteur(Auteur auteur);
    }
}
