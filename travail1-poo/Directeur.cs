using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using gestion;
using System.IO;
using travail1poo;


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

