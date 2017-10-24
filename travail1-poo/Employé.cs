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
        public float Salaire;

        public Employé(string a, string b, float c)
        {
            this.Name = a;
            this.Date = b;
            this.Salaire = c;
        }

<<<<<<< HEAD
        public string Encode()
=======
        public string encode()
        {
            return string.Format("{0}", Name);
        }
        
        public string encode()
>>>>>>> 37d05a27032ae43378fe838c333f9c5f818f5ea4
        {
            return string.Format("{0}", Name);
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}",this.Name,this.Date,this.Salaire);
        }
<<<<<<< HEAD
=======
        
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}",this.Name,this.Date,this.Salaire);
        }
>>>>>>> 37d05a27032ae43378fe838c333f9c5f818f5ea4
    }
}
