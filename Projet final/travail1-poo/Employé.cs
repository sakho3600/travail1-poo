using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using gestion;

namespace travail1poo
{
    class Employé
    {
        public string Name;
        public string Date;
        public double Salaire;

        public Employé(string a, string b, double c)
        {
            this.Name = a;
            this.Date = b;
            this.Salaire = c;
        }
        
    }
}
