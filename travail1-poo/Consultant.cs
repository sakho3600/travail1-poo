using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travail1poo
{
    class Consultant : Employé
    {
        public Societe s;
        public List<string> Clientint;
        public List<string> Clientext;

        public Consultant(string Name, string Date, float Salaire, List<string> Clientint, List<string> Clientext, Societe s) : base(Name, Date, Salaire)
        {
            this.s = s;
        }
    }
}
