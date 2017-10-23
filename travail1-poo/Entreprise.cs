using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gestion;
using Newtonsoft.Json;
using travail1poo;

namespace travail1poo
{
    class Entreprise
    {
      
        public Dictionary<string, object> Emploi;

        public Entreprise(Dictionary<string, object> ListeEmploi)
        {
            this.Emploi = ListeEmploi;
        }
        public void Encode(string a, object b)
        {
            this.Emploi.Add(a, b);
        }
        public string ListePersonnel()
            
        {
            string tot = "";
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                
                try
                {   
                   tot += String.Format("Key = {0}, Value = {1}\n", kvp.Key, kvp.Value);
                }
                catch
                {
                    return "Erreur";
                }
            }
            return tot;
        }



    }
}
