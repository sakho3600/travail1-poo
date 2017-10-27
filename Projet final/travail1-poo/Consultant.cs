﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using gestion;

namespace travail1poo
{
    class Consultant : Employé
    {
        public string Client;
        public string manageur;
        private double SalaireBoss;
        public int Annee;

        public Consultant(string Name, string Date, double Salaire,List<string> manageur, string Client) : base(Name, Date, Salaire)
        {
            this.Name = Name;
            this.Client = Client;
            this.manageur = manageur[0];
        }

        public string Poste()
        {
            return "Consultant";
        }

        public string Nom()
        {
            return this.Name;
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
                    k["interne"] = p;
                    l[nom]= k;
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
        public void GetSalaireBoss(double salaire,int annee)
        {
            SalaireBoss = salaire;
            Annee = annee;

        }

        private Dictionary<string, Dictionary<string, List<DateTime>>> HoraireParAnnnee(int year)
        {
            Dictionary<string, Dictionary<string, List<DateTime>>> l = new Dictionary<string, Dictionary<string, List<DateTime>>>();
            foreach (KeyValuePair<string, Dictionary<string, List<DateTime>>> kvp in Horaire())
            {
                foreach (KeyValuePair<string, List<DateTime>> lol in kvp.Value)
                {
                    
                    if (lol.Value[0].Year == year)
                    {
                        Dictionary<string, List<DateTime>> a = new Dictionary<string, List<DateTime>>();
                        a.Add(lol.Key, lol.Value);
                        l[kvp.Key] = a;
                    }
                }
            }
            return l;

        }

        public double SetSalaireTotal()
        {
            int CompteurMission = 0;
            int CompteurInterne=0;
            int CompteurVide = 0;
            double SalaireTotal = 0;
            foreach (KeyValuePair<string, Dictionary<string, List<DateTime>>> kvp in HoraireParAnnnee(Annee))
            {
                foreach (KeyValuePair<string, List<DateTime>> lol in kvp.Value)
                {
                    if (lol.Key == "externe")
                    {
                        if ((lol.Value[1].Year == Annee))
                        {
                            CompteurMission++;
                        }
                    }
                    else if (lol.Key == "interne")
                    {
                        if (lol.Value[1].Year == Annee)
                        {
                            TimeSpan sub = lol.Value[1] - lol.Value[0];
                            string[] a = String.Format("{0}", sub).Split('.');
                            CompteurInterne += Int32.Parse(a[0]);
                        }
                        else if(lol.Value[1].Year != Annee && lol.Value[0].Year==Annee)
                        {
                            string b = String.Format("31/12/{0}", Annee);
                            TimeSpan sub = Convert.ToDateTime(b) - lol.Value[0];
                            string[] c = String.Format("{0}", sub).Split('.');
                            CompteurInterne += Int32.Parse(c[0]);
                        }
                    }
                    

                }
            }

                SalaireTotal = this.Salaire+(CompteurMission * 250) + (CompteurInterne * ((0.01 * SalaireBoss) - 10));
                return SalaireTotal;


                
            }


        public string Agenda(DateTime dateTime)
        {
            string tot = "";
            foreach (KeyValuePair<string, Dictionary<string, List<DateTime>>> kvp in Horaire())
            {
                foreach (KeyValuePair<string, List<DateTime>> lol in kvp.Value)
                {
                    if(dateTime>lol.Value[0]&& dateTime < lol.Value[1])
                    {
                        tot += String.Format("{0}:{1}:{2}:{3} au {4}", this.Name, kvp.Key, lol.Key, lol.Value[0], lol.Value[1]);
                    }
                }
            }
            return tot;
        }

        public string Entreprise(string entreprise)
        {
            string tot = "";
            foreach (KeyValuePair<string, Dictionary<string, List<DateTime>>> kvp in Horaire())
            {
                foreach (KeyValuePair<string, List<DateTime>> lol in kvp.Value)
                {
                    if (kvp.Key == entreprise)
                    {
                        tot += String.Format("{0}={1} au {2}", kvp.Key, lol.Value[0], lol.Value[1]);
                    }
                }
            }
            return tot;
        }

    }
}