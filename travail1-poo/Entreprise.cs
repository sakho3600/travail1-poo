using System;
using System.Collections.Generic;

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
                else if (kvp.Value is Directeur_RH)
                {
                    Directeur_RH dirrh = (Directeur_RH)kvp.Value;
                    ListePersonnel.Add(kvp.Key, dirrh.Poste());
                }
                else if (kvp.Value is Finance)
                {
                    Finance dirf = (Finance)kvp.Value;
                    ListePersonnel.Add(kvp.Key, dirf.Poste());
                }
                else if (kvp.Value is Employé)
                {
                    Employé empl = (Employé)kvp.Value;
                }
			}
            return ListePersonnel;
        }

        public string SetListEntreprise(string entreprise)
        {
            Dictionary<string,string> ListConsultant = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                if(kvp.Value is Consultant)
                {
                    Consultant consul = (Consultant)kvp.Value;

                    string[] e = consul.Entreprise(entreprise).Split('=');
                    
                    if (e[0] != "")
                    {
                        ListConsultant.Add(consul.Nom(), e[1]);
                    }
                }

            }

            string b = "";
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                if (kvp.Value is Directeur_RH)
                {
                    Directeur_RH dirrh = (Directeur_RH)kvp.Value;
                    b = dirrh.Nom();
                }

            }

            if (Emploi[b] is Directeur_RH)
            {
                Directeur_RH dirrh = (Directeur_RH)Emploi[b];
                return dirrh.GetListEntreprise(entreprise, ListConsultant);
            }
            else
            {
                return "erreur";
            }
        }

        public string SetListConsultant(string ManageurName)
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
                string texte = "Erreur vous n'avez pas mis le nom d'un manageur\nVoici la liste de nos manageur:\n";
                foreach (KeyValuePair<string, string> kvp in Personnel())
                {
                    if (kvp.Value == "Manageur")
                    {
                        texte += String.Format("{0}\n", kvp.Key);
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
      
        