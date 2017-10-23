namespace interface
{
    public static void Main(string[] args)
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
                // manager
                break;
            case 2:
                Console.WriteLine("case 2");
                //RH
                break;
            case 3:
                Console.WriteLine("case 3");
                //financier
                break;
        }
    }
}