using System;
using System.Collections.Generic;

namespace travail1poo
{
    class Finance : Directeur
    {


        public Finance(string Name, string Date, double Salaire, List<string> fonction) : base(Name, Date, Salaire, fonction)
        {
        }

        public string GetListSalaire(Dictionary<string,double> ListSalaire)
        {
            string Texte = "Liste des Salaire :\n\n";
            foreach (KeyValuePair<string, double> lol in ListSalaire)
            {
                Texte += String.Format("    {0}:{1}\n", lol.Key, lol.Value);
            }
            return Texte;
        }
    }
}
