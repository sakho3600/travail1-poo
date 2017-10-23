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
        public Dictionary<string, object> Emploi;

        public Employé()
        {
            this.Emploi = new Dictionary<string, object>;
        }
        public encode(string a, object b)
        {
            Emploi.Add(a, b);
        }
        


    }


}


