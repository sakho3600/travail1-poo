using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travail1poo
{
    class Affichage
    {
        public static void Affiche(Entreprise societe)
        {
            Menu(societe);
            
        }

        public static void Menu(Entreprise societe)
        {
            Console.WriteLine("Gestionnaire d'employés.\r\nVeuillez choisir un rapport à générer:\r\n");
            Console.WriteLine("1. Générer un rapport pour le manager.");
            Console.WriteLine("2. Générer un rapport pour le directeur des resources humaines.");
            Console.WriteLine("3. Générer un rapport pour le directeur financier");

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
                    cas1(societe);
                    break;
                case 2:
                    cas2(societe);
                    break;
                case 3:
                    cas3(societe);
                    break;
            }
            retour(societe);
        }

        public static void cas1(Entreprise societe)
        {
            Console.Clear();
            Console.WriteLine("Choisissez le manager pour lequel le rapport doit être généré:");
            string response1 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(societe.SetListConsultant(response1));
        }

        public static void cas2(Entreprise societe)
        {
            Console.Clear();
            Console.WriteLine("Choisissez l'entreprise dont vous voulez voir la liste de nos consultant qui y ont travaillé:");
            string response2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(societe.SetListEntreprise(response2));
        }

        public static void cas3(Entreprise societe)
        {
            Console.Clear();
            Console.WriteLine("Choisissez une Année:");
            string response3 = Console.ReadLine();
            int choise = 0;
            choise = Int16.Parse(response3);
            Console.Clear();
            Console.WriteLine(societe.SetListSalaire(societe.DirecteurFinance(), choise));
        }
        public static void retour(Entreprise societe)
        {
            Console.WriteLine("Voulez vous quittez l'interface ? (y/n)");
            string response4 = Console.ReadLine();
            if (response4 == "n")
            {
                Console.Clear();
                Menu(societe);
            }
            else if (response4 == "y")
            {
                Console.Clear();
                Console.WriteLine("Merci de votre visite !");
            }
            else
            {
                Console.WriteLine("Vous n'avez pas effectué la bonne commande");
                retour(societe);
            }
        }

    }
    
}
