using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Directeur_RH : Directeur
    {

 
    
        public Directeur_RH(string Name, string Date, double Salaire, List<string> fonction) : base(Name, Date, Salaire, fonction)
        {
 
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
