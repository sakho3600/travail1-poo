using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Finance : Directeur
    {
        public new string fonction;

        public Finance(string Name, string Date, float Salaire, List<string> fonction) : base(Name, Date, Salaire, fonction)
        {
            this.fonction = fonction[0];
        }

        public new string Poste()
        {
            return String.Format("Directeur {0}", fonction);
        }

        public string Nom()
        {
			return this.Name;
        }

        public string GetListSalaire(Dictionary<string,double> ListSalaire)
        {
            string Texte = "Liste des Salaire :\n";
            foreach (KeyValuePair<string, double> lol in ListSalaire)
            {
                Texte += String.Format("{0}:{1}\n", lol.Key, lol.Value);
            }
            return Texte;
        }
    }
}
