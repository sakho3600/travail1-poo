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

<<<<<<< HEAD
        public Dictionary<string, string> Personnel()

=======
        public string ListePersonnel()
            
>>>>>>> 37d05a27032ae43378fe838c333f9c5f818f5ea4
        {
            Dictionary<string, string> ListePersonnel = new Dictionary<string, string>();
            
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                if (kvp.Value is Consultant)
                {
                    Consultant consul = (Consultant)kvp.Value;
<<<<<<< HEAD
                    ListePersonnel.Add(kvp.Key, consul.Poste());
                }
                else if (kvp.Value is Manageur)
                {
                    Manageur manag = (Manageur)kvp.Value;
                    ListePersonnel.Add(kvp.Key, manag.Poste());
                }
                else if(kvp.Value is Directeur)
                {
                    Directeur dir = (Directeur)kvp.Value;
                    ListePersonnel.Add(kvp.Key, dir.Poste());
=======
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
>>>>>>> 37d05a27032ae43378fe838c333f9c5f818f5ea4
                }
                else
                {
                    Console.WriteLine("Erreur dans la database");
                }
            }
            return ListePersonnel;
        }
<<<<<<< HEAD
        public override string ToString()

        {
            string tot = "";
            foreach (KeyValuePair<string, string> kvp in Personnel())
            {
                tot+= String.Format("{0}:{1}\n",kvp.Key,kvp.Value);
            }
            return tot;
                
        }
=======
>>>>>>> 37d05a27032ae43378fe838c333f9c5f818f5ea4
    }
}
      
        