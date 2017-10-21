using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using travail1poo;

namespace gestion
{


    public class RootObject
    {   public string ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public float Salaire { get; set; }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string data = System.IO.File.ReadAllText(@"dataemployé.json");
            Traduction(data);
            Console.ReadKey();
        }

        static void Traduction(string data)
        {
            var h = JsonConvert.DeserializeObject<List<RootObject>>(data);
            int count = h.Count;
            for(int i=0;i<count;i++)
            {
                Employé h[i].ID = new Employé(h[i].Name, h[i].Date, h[i].Salaire);
            }



        }
    }
    
}
