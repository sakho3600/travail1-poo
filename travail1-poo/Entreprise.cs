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

        public Dictionary<string, string> Personnel()

        {
            Dictionary<string, string> ListePersonnel = new Dictionary<string, string>();
            
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                if (kvp.Value is Consultant)
                {
                    Consultant consul = (Consultant)kvp.Value;
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
                }
                else if (kvp.Value is Employé)
                {
                    Employé empl = (Employé)kvp.Value;
                }
			}
            return ListePersonnel;
        }
        public string SetlistConsultant(string ManageurName)
        {
            List<string> ListConsultant = new List<string>();
            if(Emploi[ManageurName] is Manageur)
            {
                Manageur manag = (Manageur)Emploi[ManageurName];
                List<string> a = new List<string>(manag.Esclave());
                for (int i = 0; i < a.Count; i++)
                {
                    foreach (KeyValuePair<string, object> kvp in Emploi)
                    {
                        if (kvp.Key == a[i])
                        {
                            Consultant consul = (Consultant)kvp.Value;
                            ListConsultant.Add(consul.Agenda(DateTime.Today));

                        }
                    }
                }
                return manag.GetListConsultant(ListConsultant);

            }
            else
            {
                string texte = "Erreur vous n'avez pas mis le nom d'un manageur\n Voici la liste de nos manageur:\n";
                foreach (KeyValuePair<string, string> kvp in Personnel())
                {
                    if (kvp.Value == "Manageur")
                    {
                        texte += String.Format("{}", kvp.Key);
                    }
                }
                return texte;


            }

        }

        public override string ToString()

        {
            string tot = "";
            foreach (KeyValuePair<string, string> kvp in Personnel())
            {
                tot+= String.Format("{0}:{1}\n",kvp.Key,kvp.Value);
            }
            return tot;
                
        }
    }
}
      
        