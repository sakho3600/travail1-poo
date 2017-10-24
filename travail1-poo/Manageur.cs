using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using gestion;

namespace travail1poo
{
    class Manageur : Employé
    {
        public List<Consultant> Consult;

        public Manageur(string Name, string Date, float Salaire) : base(Name, Date, Salaire)
        {
            this.Consult = Consult;
        }
        public string Poste()
        {
            return "Manageur";
        }
    }
}
