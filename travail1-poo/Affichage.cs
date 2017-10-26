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
                    Console.WriteLine("Choisissez le manager pour lequel le rapport doit être généré.");
                    string response = Console.ReadLine();
                    Console.WriteLine(societe.SetListConsultant(response));
                    break;
                case 2:
                    Console.WriteLine("Choisissez le manager pour lequel le rapport doit être généré.");
                    string reponse = Console.ReadLine();
                    Console.WriteLine(societe.SetListEntreprise(reponse));
                    break;
                case 3:
                    Console.WriteLine("case 3");
                    //financier
                    break;
            }
        }
    }
    
}
