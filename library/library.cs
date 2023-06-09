﻿using login;

namespace library
{
    public class Program
    {
        public static void LibraryPage()
        {
            profilestart: 
            Console.Clear();
            Console.WriteLine("Välkommen till Biblioteket!");
            Console.WriteLine("vad vill du göra?");
            Console.WriteLine("(1)Se alla böcker");
            Console.WriteLine("(2)Söka efter en bok");
            Console.WriteLine("(3)Gå till din profil");
            int library = Convert.ToInt32(Console.ReadLine());
            if (library == 1)
            {
                Books();
            }
            else if (library == 2)
            {
                BookSearch.Program.FussySearch();
            }
            else if (library == 3)
            {
                profile.Program.ProfilePage();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Felaktig Input");
                goto profilestart;
            }
        }
        public static void Books()
        {
            Console.Clear();
            string[] books = System.IO.File.ReadAllLines(@"C:\Users\klara\source\repos\Library\library\books.txt");
            for (int i = 0; i < books.Length; i++)
            {
                var line = books[i].Trim();
                string[] parts = line.Split(',');
                Console.WriteLine("(" + i + ")" + parts[0] + " av " + parts[1]);
                Console.WriteLine(" ");
            }
            
            Console.WriteLine("Välj en bok");
            int BookChosen = Convert.ToInt32(Console.ReadLine());
            var BookInfo = books[BookChosen].Trim();
            string[] BookParts = BookInfo.Split(',');
            Console.Clear();
            Console.WriteLine("titel: " +BookParts[0]);
            Console.WriteLine("Författare: " +BookParts[1]);
            Console.WriteLine("Genre: " +BookParts[2]);
            Console.WriteLine(BookParts[3]);
            Console.WriteLine("Böcker tillgängliga: " +BookParts[4]);

            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("(1)Låna boken");
            int LoanOrReserve = Convert.ToInt32(Console.ReadLine());
            if (LoanOrReserve == 1)
            {

                int newAvailability = Int32.Parse(BookParts[4])-1;
                BookParts[4] = $",{Convert.ToString(newAvailability)}";
                books[BookChosen] = $"{BookParts[0]},{BookParts[1]},{BookParts[2]},{BookParts[3]},{BookParts[4]}";


   
                    Console.WriteLine("Vad vill du göra nu?");
                    Console.WriteLine("(1)Se fler böcker");
                    Console.WriteLine("(2)Gå till profilsidan");
                    
                        int bib = Convert.ToInt32(Console.ReadLine());
                        if (bib == 1)
                        {
                            library.Program.LibraryPage();

                        }
                        else if (bib == 2)
                        {
                            profile.Program.ProfilePage();

                        }
                


                
            }
        }
    }
}
