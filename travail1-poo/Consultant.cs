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
        public List<string> manageur;

        public Consultant(string Name, string Date, float Salaire,List<string> manageur, string Client) : base(Name, Date, Salaire)
        {
            this.Client = Client;
            this.manageur = manageur;

        }
        public string Poste()
        {
            return "Consultant";
        }
        private Dictionary<string,List<DateTime> >Horaire()
        {
            var h = JsonConvert.DeserializeObject<List<DataClient>>(this.Client);
            int a = h.Count;
            Dictionary<string, List<DateTime>> l = new Dictionary<string, List<DateTime>>();
            List<DateTime> k = new List<DateTime>();
            TimeSpan e;
            for (int i = 0; i < a; i++)
            {

                if (h[i].Name == "Interne")
                {
                    DateTime c = Convert.ToDateTime(h[i].DateStart);
                    DateTime d = Convert.ToDateTime(h[i].DateEnd);
                    e = d - c;

                }
                else
                {
                    List<DateTime> b = new List<DateTime>();
                    DateTime c = Convert.ToDateTime(h[i].DateStart);
                    DateTime d = Convert.ToDateTime(h[i].DateEnd);
                    b.Add(c);
                    b.Add(d);
                    l[h[i].Name] = b;
                }



            }
            return l;
        }
        public string Agenda()
        {
            string tot = "";
            foreach (KeyValuePair<string, List<DateTime>> kvp in Horaire())
            {

                    tot += String.Format("{0}:({1}-{2})\n", kvp.Key, kvp.Value[1],kvp.Value[0]);
            }
            return tot;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}\n{3}", this.Name, this.Date, this.Salaire,this.Client);
        }
    }
}
