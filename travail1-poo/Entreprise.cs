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

        // Fonction Encode permet de rejouter un employé dans le dictionnaire Emploi//

        public void Encode(string a, object b)
        {
            this.Emploi.Add(a, b);
        }

        // Fonction personnel revoie un dictionnaire des noms des employés et leurs postes //

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

        // Fonction SetSalaire envoie le salaire des manageur à leurs consultants pour que ceux-ci puisse calculer leur salaire //

        public void SetSalaire(int annee)
        {
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                if(kvp.Value is Manageur)
                {
                    Manageur manag = (Manageur)kvp.Value;
                    List<string>e = new List<string>(manag.Esclave());
                    for (int i = 0; i < e.Count; i++)
                    {
                        if(Emploi[e[i]] is Consultant)
                        {
                            Consultant consul = (Consultant)Emploi[e[i]];
                            consul.GetSalaireBoss(manag.SetSalaireTotal(),annee);
                        }
                    }
                }
            }

        }

        // Fonction DirecteurFinance renvoi le Nom du directur des Finance de l'entreprise  //

        public string DirecteurFinance()
        {
            string Nom = "";
            foreach (KeyValuePair<string, object> kvp in Emploi)
            {
                if(kvp.Value is Finance)
                {
                    Nom = kvp.Key;
                }
            }
            return Nom;
        }

        // Fonction SelListSalaire envoie à la classe Finance un dictionnaire des Noms et des salaire pour que l'intance de cette classe puisse renvoie la Liste des salaires //

        public string SetListSalaire(string Directeur,int annee)
        {
            Dictionary<string, double> ListSalaire = new Dictionary<string, double>();
            
            SetSalaire(annee);
            foreach (KeyValuePair<string, object> lol in Emploi)
            {
                {
                    if (lol.Value is Consultant)
                    {
                        Consultant consul = (Consultant)lol.Value;
                        ListSalaire.Add(lol.Key, consul.SetSalaireTotal());
                    }
                    else if (lol.Value is Manageur)
                    {
                        Manageur manag = (Manageur)lol.Value;
                        ListSalaire.Add(lol.Key, manag.SetSalaireTotal());
                    }
                    else if (lol.Value is Directeur)
                    {
                        Directeur dir = (Directeur)lol.Value;
                        ListSalaire.Add(lol.Key, dir.SetSalaireTotal());
                    }
                    else if (lol.Value is Directeur_RH)
                    {
                        Directeur_RH dirrh = (Directeur_RH)lol.Value;
                        ListSalaire.Add(lol.Key, dirrh.SetSalaireTotal());
                    }
                    else if (lol.Value is Finance)
                    {
                        Finance dirf = (Finance)lol.Value;
                        ListSalaire.Add(lol.Key, dirf.SetSalaireTotal());
                    }

                }
            }
            try
            {
                if (Emploi[Directeur] is Finance)
                {
                    Finance sal = (Finance)Emploi[Directeur];
                    return sal.GetListSalaire(ListSalaire);
                }
                else
                {
                    return "Erreur dans la base de donnée ou dans la classe entreprise";
                }
            }
            catch
            {
                return " Erreur dans la base de donnée ou dans la classe entreprise";
            }


        }

        // Fonction SelListEntreprise envoie à la classe Directeur_RH un dictionnaire des Noms et des date pour que l'intance de cette classe puisse renvoie la Liste des Consultants //
        // travaillant dans une entreprise donnée//

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

        // Fonction SelListConsultant envoie à la classe Manageur une liste des Noms des consultant et de lentreprise où ils travaillent pour que l'intance de cette classe puisse renvoyé cette liste  //


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

    }
}
      
        