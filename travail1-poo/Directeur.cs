using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using gestion;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using travail1poo;


namespace travail1poo
{
    class Directeur:Employé
    {
        
        public List<Manageur> Manag;
        public List<Consultant> Consult;

        public Directeur(string Name, string Date, float Salaire, List<Manageur> Manag, List<Consultant> Consult) : base(Name, Date, Salaire)
        {
            this.Manag = Manag;
            this.Consult = Consult;
        }


        


    }
}

