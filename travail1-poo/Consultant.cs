using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travail1poo
{
    class Consultant : Employé
    {
        //public Societe s;
        public string Client;
        public List<string> manageur;

        public Consultant(string Name, string Date, float Salaire,List<string> manageur, string Client) : base(Name, Date, Salaire)
        {
            this.Client = Client;
            this.manageur = manageur;

        }
        public string Poste()
        {
            return "Consultant";
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}\n{3}", this.Name, this.Date, this.Salaire,this.Client);
        }
    }
}
