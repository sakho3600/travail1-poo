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
        public override string ToString()
        {
            return string.Format("{0}\n {1}\n {2}", Name, Date, Salaire);
        }

    }

    class Directeur : Employé
    {
        public List<Manageur> Manag;
        public List<Consultant> Consult;

        public Directeur (string Name, string Date, float Salaire, List<Manageur> Manag, List<Consultant> Consult):base(Name, Date, Salaire)
        {
            this.Manag = Manag;
            this.Consult = Consult;


        }


    }
    class Manageur : Employé
    {
        public List<Consultant> Consult;

        public Manageur (string Name, string Date, float Salaire,List<Consultant>Consult):base(Name, Date, Salaire)
        {
            this.Consult = Consult;
        }
    }
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
    class Societe
    {

    }

}


