using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travail1poo
{
    class Affichage
    {
        public static Entreprise societe;
        public string session;
        public Affichage(Entreprise entreprise)
        {
            societe =entreprise;
        }
        public void Affiche()
        {
            login();
            
        }
        private static void login()
        {
            Console.WriteLine("Nom : ");
            string Nom = Console.ReadLine();
            string session = societe.Poste(Nom);
            if (session != "No found")
            {
                Menu(session, Nom);
            }
            else
            {
                Console.Clear();
                Console.Write("Erreur le nom utilisé nest pas repertorié\n");
                login();
            }
        }
        private static void Menu(string session,string Nom)
        {
            Console.Clear();
            Console.WriteLine(String.Format("Session:{0} {1}\n",session,Nom));
            Console.WriteLine("Gestionnaire d'employés:\nVeuillez choisir un rapport à générer:\n");
            Console.WriteLine("1. Générer un rapport des consultant et de leurs clients actuels.");
            Console.WriteLine("2. Générer un rapport des consultant ayant travaillé dans une entreprise donnée.");
            Console.WriteLine("3. Générer un rapport des salaires du personnel pour une annnée donnée.");

            int choice = 0;

            try
            {
                string response = Console.ReadLine();
                choice = int.Parse(response);

                if ((0 >= choice) || (choice >= 4))
                {
                    throw new System.Exception();
                }
            }
            catch
            {
                Console.WriteLine("Veuillez entrer un chiffre entre 1 et 3.");
            }
            switch (choice)
            {
                case 1:
                    if (session == "Manageur")
                    {
                        cas4(session,Nom);
                        break;
                    }
                    else if (session == "Directeur Principal")
                    {
                        cas1(session);
                        break;
                    }
                    else
                    {
                        error(session,Nom);
                        break;
                    }
                case 2:
                    if (session == "Directeur RH" || session == "Directeur Principal")
                    {
                        cas2(session);
                        break;
                    }
                    else
                    {
                        error(session,Nom);
                        break;
                    }
                case 3:
                    if (session == "Directeur Finance" || session == "Directeur Principal")
                    {
                        cas3(session);
                        break;
                    }
                    else
                    {
                        error(session,Nom);
                        break;
                    }
            }
            retour(session,Nom);
        }

        private static void cas1(string session)
        {
            try
            {
                Console.WriteLine("Choisissez le manager pour lequel le rapport doit être généré:");
                string response1 = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(societe.SetListConsultant(response1));
            }
            catch
            {
                Console.WriteLine("Veillez un Nom de Manageur valide\nExemple:Google");
                cas1(session);

            }
        }
        private static void error(string session,string nom)
        {
            Console.WriteLine("Vous ne possèdé pas les droits pour réaliser cette action !");
            retour(session,nom);
        }

        private static void cas2(string session)
        {
            try
            {
                Console.WriteLine("Choisissez l'entreprise dont vous voulez voir la liste de nos consultant qui y ont travaillé:");
                string response2 = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(societe.SetListEntreprise(response2));
            }
            catch
            {
                Console.WriteLine("Veillez un Nom d'entreprise valide\nExemple:Google");
                cas2(session);
            }
        }

        private static void cas3(string session)
        {

            Console.WriteLine("Choisissez une Année:");
            try
            {
                string response3 = Console.ReadLine();
                int choise = 0;
                choise = Int16.Parse(response3);
                Console.Clear();
                Console.WriteLine(societe.SetListSalaire(choise));
            }
            catch
            {
                Console.WriteLine("Veillez rentrer une année valide\nExemple:2017");
                cas3(session);
            }
        }
        private static void cas4(string session, string Nom)
        {
            Console.Clear();
            Console.Write("Votre rapport:\n");
            Console.WriteLine(societe.SetListConsultant(Nom));


        }
        private static void retour(string session,string Nom)
        {
            Console.WriteLine("Voulez vous vous deconnectez ? (y/n)");
            string response4 = Console.ReadLine();
            if (response4 == "n")
            {
                Console.Clear();
                Menu(session,Nom);
            }
            else if (response4 == "y")
            {
                Console.Clear();
                login();
            }
            else
            {
                Console.WriteLine("Vous n'avez pas effectué la bonne commande");
                retour(session,Nom);
            }
        }

    }
    
}
