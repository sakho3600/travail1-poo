using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using travail1poo;
using gestion;

namespace travail1poo
{
    class Consultant : Employé
    {
        //public Societe s;
        public string Client;
        public string manageur;

        public Consultant(string Name, string Date, float Salaire,List<string> manageur, string Client) : base(Name, Date, Salaire)
        {
            this.Client = Client;
            this.manageur = manageur[0];

        }
        public string Poste()
        {
            return "Consultant";
        }
        private Dictionary<string,Dictionary<string,List<DateTime>>>Horaire()
        {
            var h = JsonConvert.DeserializeObject<List<DataClient>>(this.Client);
            int a = h.Count;
            Dictionary < string,Dictionary < string,List<DateTime> >> l = new Dictionary<string, Dictionary<string,List< DateTime>>> ();
            for (int i = 0; i < a; i++)
            {

                if (h[i].Name == "Interne")
                {
                    Dictionary<string, List<DateTime>> k = new Dictionary<string, List<DateTime>>();
                    List<DateTime> p = new List<DateTime>();
                    DateTime c = Convert.ToDateTime(h[i].DateStart);
                    DateTime d = Convert.ToDateTime(h[i].DateEnd);
                    string nom = String.Format("{0} {1}", h[i].Name, i);
                    p.Add(c);
                    p.Add(d);
                    k["Interne"] = p;
                    l[nom ]= k;
                }
                else
                {
                    Dictionary<string, List<DateTime>> k = new Dictionary<string, List<DateTime>>();
                    List<DateTime> b = new List<DateTime>();
                    DateTime c = Convert.ToDateTime(h[i].DateStart);
                    DateTime d = Convert.ToDateTime(h[i].DateEnd);
                    b.Add(c);
                    b.Add(d);
                    k["externe"] = b;
                    l[h[i].Name] = k;

                }



            }
            return l;
        }
        private float CalculSalaireTotal()
        {
            int CompteurMission = 0;
            int CompteurInterne=0;
            foreach (KeyValuePair<string, Dictionary<string, List<DateTime>>> kvp in Horaire())
            {
                foreach (KeyValuePair<string, List<DateTime>> lol in kvp.Value)
                {
                    if (lol.Key is "externe")
                    {
                        CompteurMission++;
                    }
                    else if (lol.Key is "interne")
                    {
                        TimeSpan sub = lol.Value[1] - lol.Value[0];
                        string a = String.Format("{}", sub);
                        CompteurInterne += Int32.Parse(a);
                    }
                }
            }


        return 0;
        }
        public string Agenda()
        {
            string tot = "";
            foreach (KeyValuePair<string, Dictionary<string, List<DateTime>>> kvp in Horaire())
            {
                foreach (KeyValuePair<string, List<DateTime>> lol in kvp.Value)
                {
                    tot += String.Format("{0}:{1}:{2} au {3}\n", kvp.Key, lol.Key, lol.Value[0], lol.Value[1]);

                }


            }
            return tot;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}\n{3}", this.Name, this.Date, this.Salaire,this.Client);
        }
    }
}
