using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using gestion;

namespace travail1poo
{
    class Manageur : Employé
    {
        public List<string> Consult;
        private float Salaire;

        public Manageur(string Name, string Date, float Salaire, List<string> consultant) : base(Name, Date, Salaire)
        {
            this.Consult = consultant;
            this.Salaire = Salaire;
        }
        public float SalaireTotal()
        {
            float Total = this.Salaire + (500 * this.Consult.Count);
            return Total;
        }
        public string Poste()
        {
            return "Manageur";
        }
        public Dictionary<string,string> GetListConsultant()
        {
            Dictionary<string, string> ListConsultant = new Dictionary<string, string>();
            return ListConsultant;
        }
    }
}
