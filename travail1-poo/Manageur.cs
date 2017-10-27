using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Manageur : Employé
    {
        private List<string> Consult;

        public Manageur(string Name, string Date, double Salaire, List<string> consultant) : base(Name, Date, Salaire)
        {
            this.Consult = consultant;
        }

        public double SetSalaireTotal()
        {
            double Total = this.Salaire + (500 * this.Consult.Count);
            return Total;
        }

        public string Poste()
        {
            return "Manageur";
        }

        public List<string> Esclave()
        {
            return this.Consult;
        }

        public string GetListConsultant(List<string> agenda)
        {
            string ListConsultant = "";
            for(int i=0; i<agenda.Count; i++)
            {
                ListConsultant +=String.Format("{0}\n",agenda[i]);
            }

            return ListConsultant;
        }
    }
}
