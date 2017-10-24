using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using travail1poo;

namespace gestion
{
<<<<<<< HEAD
=======


>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
    public class DataEmploye
    {   public string Poste { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public float Salaire { get; set; }
<<<<<<< HEAD
    }

=======

    }
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
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
<<<<<<< HEAD
            // Console.WriteLine(Ecam.ListePersonnel());
            Ecam.ListePersonnel();
            // Console.ReadKey();
=======
            Console.WriteLine(Ecam.ListePersonnel());
            Console.ReadKey();
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
        }

        static Dictionary<string,object> Emploi()
        {
            Dictionary<string, object> ListEmploi = new Dictionary<string, object>();
<<<<<<< HEAD
            string data = System.IO.File.ReadAllText(@"Dataemployé.json");
=======
            string data = System.IO.File.ReadAllText(@"dataemployé.json");
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
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
                    default:
                        Employé employé = new Employé(h[i].Name, h[i].Date, h[i].Salaire);
                        ListEmploi.Add(h[i].Name, employé);
                        break;
<<<<<<< HEAD
                }
            }

            return ListEmploi;
=======

                }

            }
            return ListEmploi;
 
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
        }

        static List<string> LectureName()
        {
            List<string> ListName = new List<string>();
<<<<<<< HEAD
            string data = System.IO.File.ReadAllText(@"Dataemployé.json");
            var h = JsonConvert.DeserializeObject<List<DataEmploye>>(data);
            int cont = h.Count;

=======
            string data = System.IO.File.ReadAllText(@"dataemployé.json");
            var h = JsonConvert.DeserializeObject<List<DataEmploye>>(data);
            int cont = h.Count;
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
            for (int i = 0; i < cont; i++)
            {
                ListName.Add(h[i].Name);
            }
<<<<<<< HEAD

=======
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
            return ListName;
        }

        static List<string> LectureAdress()
        {
            List<string> ListAdress = new List<string>();
            string AdressList = System.IO.File.ReadAllText(@"Dataadress.json");
            var p = JsonConvert.DeserializeObject<List<string>>(AdressList);
            int cont1 = p.Count;
<<<<<<< HEAD
        
=======
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
            for (int i = 0; i < cont1; i++)
            {
                ListAdress.Add(p[i]);
            }
            return ListAdress;

        }
<<<<<<< HEAD
=======

>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
        static Dictionary<string,string>Traduction(List<string> ListName, List<string> ListAdress)
        {
            string a = System.IO.File.ReadAllText(@"Dataadress.json");
            var b = JsonConvert.DeserializeObject<List<string>>(a);
            int cont1 = b.Count;
            Dictionary<string, string> Adresse = new Dictionary<string, string>();
<<<<<<< HEAD
         
=======
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
            for(int i = 0; i < cont1; i++)
            {
                Adresse.Add(ListName[i], ListAdress[i]);
            }
<<<<<<< HEAD

            return Adresse;
        }
    }
=======
            return Adresse;
            
        }
    }
    
>>>>>>> 33d999743500e715d47ace360cc34679bfe56a7e
}
