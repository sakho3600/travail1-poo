using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Directeur:Employé
    {

        public string fonction;

        public Directeur(string Name, string Date, double Salaire, List<string> fonction) : base(Name, Date, Salaire)
        {
            this.fonction = fonction[0];
            this.Salaire = Salaire;
            this.Name = Name;
        }
        public string Poste()
        {
            return String.Format("Directeur {0}",fonction);
        }

        public string Nom()
        {
            return this.Name;
        }

        public double SetSalaireTotal()
        {
            return this.Salaire;
        }
    }
}
