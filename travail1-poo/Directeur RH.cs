using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Directeur_RH : Directeur
    {

        public string fonction;
        public string Name;
 
    
        public Directeur_RH(string Name, string Date, float Salaire, List<string> fonction) : base(Name, Date, Salaire, fonction)
        {
            this.fonction = fonction[0];
            this.Name = Name;
 
        }

        public string Poste()
        {
            return String.Format("Directeur {0}", fonction);
        }

        public string Nom()
        {
            return this.Name;
        }

        public string GetListEntreprise(string entreprise,Dictionary<string,string> ListEntreprise)
        {
            string texte = String.Format("{0}:\n\n",entreprise);
            foreach (KeyValuePair<string, string> kvp in ListEntreprise)
            {
                texte += String.Format("  {0}:{1}\n", kvp.Key, kvp.Value);
            }
            return texte;
        }
    }
}
