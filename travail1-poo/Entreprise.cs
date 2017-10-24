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
                if (kvp.Value is Consultant)
                {
                    Consultant consul = (Consultant)kvp.Value;
                    Console.WriteLine(consul.Poste());
                }
                else if (kvp.Value is Employé)
                {
                    Employé empl = (Employé)kvp.Value;
                    Console.WriteLine(empl.encode());
                }
			}
            return tot;
        }
    }
}
