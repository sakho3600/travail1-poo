using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using travail1poo;

namespace gestion
{
    public class DataEmploye
    {
        public string Poste { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public double Salaire { get; set; }
        public List<string> Associe { get; set; }
    }

    public class DataClient
    {
        public string Name { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        { 
            Entreprise Ecam = new Entreprise(Emploi());
            Affichage cons=new Affichage(Ecam);
            cons.Affiche();
			Console.ReadKey();
        }

        // Pas touche au variable Associe
        static Dictionary<string, object> Emploi()
        {
            // Dictionaire avec le nom et l'instance des classes qu'on envoie aux entreprises
            Dictionary<string, object> ListEmploi = new Dictionary<string, object>();
            string data = System.IO.File.ReadAllText(@"Dataemployé.json");
            var h = JsonConvert.DeserializeObject<List<DataEmploye>>(data);
            // Contient le nom et l'emplacement du fichier json de chaque employé
            Dictionary<string, string> Trad = Traduction(LectureName(), LectureAdress());

            int count = h.Count;
            for (int i = 0; i < count; i++)
            {
                string b = Trad[h[i].Name];
                string Data = System.IO.File.ReadAllText(@b);
                // On crée les objets du bon type en fonction du poste
                switch (h[i].Poste)
                {
                    case "Consultant":
                        Consultant consultant = new Consultant(h[i].Name, h[i].Date, h[i].Salaire, h[i].Associe, Data);
                        ListEmploi.Add(h[i].Name, consultant);
                        break;

                    case "Manageur":
                        Manageur manageur = new Manageur(h[i].Name, h[i].Date, h[i].Salaire, h[i].Associe);
                        ListEmploi.Add(h[i].Name, manageur);
                        break;

                    case "Directeur":
                        if (h[i].Associe[0] == "Principal")
                        {
                            Directeur directeur = new Directeur(h[i].Name, h[i].Date, h[i].Salaire, h[i].Associe);
                            ListEmploi.Add(h[i].Name, directeur);
                            break;
                        }

                        else if (h[i].Associe[0] == "RH")
                        {
                            Directeur_RH directeur = new Directeur_RH(h[i].Name, h[i].Date, h[i].Salaire, h[i].Associe);
                            ListEmploi.Add(h[i].Name, directeur);
                            break;
                        }

                        else if (h[i].Associe[0] == "Finance")
                        {
                            Finance directeur = new Finance(h[i].Name, h[i].Date, h[i].Salaire, h[i].Associe);
                            ListEmploi.Add(h[i].Name, directeur);
                            break;
                        }

                        else
                        {
                            break;
                        }

                    default:
                        Employé employé = new Employé(h[i].Name, h[i].Date, h[i].Salaire);
                        ListEmploi.Add(h[i].Name, employé);
                        break;
                }
            }
            return ListEmploi;
        }

        // Renvoie la liste de tou les employés qu'on a été chercher dans le fichier json
        static List<string> LectureName()
        {
            List<string> ListName = new List<string>();
            string data = System.IO.File.ReadAllText(@"Dataemployé.json");
            var h = JsonConvert.DeserializeObject<List<DataEmploye>>(data);
            int cont = h.Count;

            for (int i = 0; i < cont; i++)
            {
                ListName.Add(h[i].Name);
            }

            return ListName;
        }

        // Renvoie la liste des fichiers json contenant les informations
        static List<string> LectureAdress()
        {
            List<string> ListAdress = new List<string>();
            string AdressList = System.IO.File.ReadAllText(@"Dataadress.json");
            var p = JsonConvert.DeserializeObject<List<string>>(AdressList);
            int cont1 = p.Count;

            for (int i = 0; i < cont1; i++)
            {
                ListAdress.Add(p[i]);
            }

            return ListAdress;
        }

        // Renvoie le nom et l'emplacement du fichier ensemble dans un dictionnaire
        static Dictionary<string, string> Traduction(List<string> ListName, List<string> ListAdress)
        {
            string a = System.IO.File.ReadAllText(@"Dataadress.json");
            var b = JsonConvert.DeserializeObject<List<string>>(a);
            int cont1 = b.Count;
            Dictionary<string, string> Adresse = new Dictionary<string, string>();

            for (int i = 0; i < cont1; i++)
            {
                Adresse.Add(ListName[i], ListAdress[i]);
            }

            return Adresse;
        }
    }
}
