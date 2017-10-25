using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travail1poo
{
    class Finance:Directeur
    { 
        public string fonction;
    
        public  Finance(string Name, string Date, float Salaire, List<string> fonction) : base(Name, Date, Salaire, fonction)
        {

            this.fonction = fonction[0];

        }
        public string Poste()
        {
            return String.Format("Directeur {0}", fonction);
        }
    }
}
