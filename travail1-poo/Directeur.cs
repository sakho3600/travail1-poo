using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Directeur:Employé
    {
        public List<Manageur> Manag;
        public List<Consultant> Consult;
        public string fonction;

        public Directeur(string Name, string Date, float Salaire, List<string> fonction) : base(Name, Date, Salaire)
        {
            this.fonction = fonction[0];
        }
        public string Poste()
        {
            return String.Format("Directeur {0}",fonction);
        }
    }
}
