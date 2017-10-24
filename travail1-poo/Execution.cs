using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using travail1poo;
using gestion;

namespace gestion
{

    public class DataEmploye
    {   public string Poste { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public float Salaire { get; set; }
        public List<string> Associe { get; set; }
    }


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
            Dictionary<string, string> Ad = Traduction(LectureName(),LectureAdress());
            Entreprise Ecam = new Entreprise(Emploi());
            Ecam.Personnel();
            Console.ReadKey();
        }

        static Dictionary<string,object> Emploi()
        {
            Dictionary<string, object> ListEmploi = new Dictionary<string, object>();
            string data = System.IO.File.ReadAllText(@"Dataemployé.json");
            var h = JsonConvert.DeserializeObject<List<DataEmploye>>(data);
            int count = h.Count;
            Dictionary<string, string> Trad = Traduction(LectureName(),LectureAdress());
            for (int i = 0; i < count; i++)
            {
                string b = Trad[h[i].Name];
                string Data = System.IO.File.ReadAllText(@b);

                switch (h[i].Poste)
                {
                    case "Consultant":
                        Consultant consultant = new Consultant(h[i].Name, h[i].Date, h[i].Salaire, Data);
                        ListEmploi.Add(h[i].Name, consultant);
                        break;
                case "Manageur":
                    Manageur manageur = new Manageur()
                    default:
                        Employé employé = new Employé(h[i].Name, h[i].Date, h[i].Salaire);
                        ListEmploi.Add(h[i].Name, employé);
                        break;
                }
            }

            return ListEmploi;

                }


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
        static Dictionary<string,string>Traduction(List<string> ListName, List<string> ListAdress)
        {
            string a = System.IO.File.ReadAllText(@"Dataadress.json");
            var b = JsonConvert.DeserializeObject<List<string>>(a);
            int cont1 = b.Count;
            Dictionary<string, string> Adresse = new Dictionary<string, string>();
            for(int i = 0; i < cont1; i++)
            {
                Adresse.Add(ListName[i], ListAdress[i]);
            }

            return Adresse;
        }
    }
    

