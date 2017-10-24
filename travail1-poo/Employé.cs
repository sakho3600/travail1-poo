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

        public string encode()
        {
            return string.Format("{0}", Name);
        }
=======
        public string encode()
        {
            return string.Format("{0}", Name);
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}",this.Name,this.Date,this.Salaire);
        }

>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}",this.Name,this.Date,this.Salaire);
        }
    }
}


