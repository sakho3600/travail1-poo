using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Directeur:Employé
    {

        public string fonction;
        public double Salaire;

        public Directeur(string Name, string Date, float Salaire, List<string> fonction) : base(Name, Date, Salaire)
        {
            this.fonction = fonction[0];
            this.Salaire = Salaire;
        }
        public string Poste()
        {
            return String.Format("Directeur {0}",fonction);
        }

        public double SetSalaireTotal()
        {
            return this.Salaire;
        }
    }
}
