using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registeration;
using login;
using library;
using profile;

namespace library
{
    public class program
    { 

        static void Main(string[] args)
        {

            inorup:
            Console.WriteLine("(1)Logga in");
            Console.WriteLine("(2)Registera dig");

            int inorup = Convert.ToInt32(Console.ReadLine());
            if (inorup == 1)
            {
                login.Program.LogInPage();
            }else if (inorup == 2)
            {
                Registeration.Program.RegistrationPage();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Felaktig Input");
                goto inorup;
            }
             string[] users = System.IO.File.ReadAllLines(@"C:\Users\klara\source\repos\Library\library\users.txt");

            
                var line = users[login.Program.ID].Trim();
                string[] parts = line.Split(' ');
            //kollar om användaren är biblotikarie
                int llibrarian = Convert.ToInt32(parts[4]);
            if (llibrarian == 0)
            {
                     Console.Clear();
                    Logged:
                    Console.WriteLine("Du är nu inloggad!");


                    Console.WriteLine("Vart vill du någonstans?");
                    Console.WriteLine("(1)Biblioteket");
                    Console.WriteLine("(2)Profilsidan");
                    int bib = Convert.ToInt32(Console.ReadLine());
                    if (bib == 1)
                    {
                        library.Program.LibraryPage();

                    }
                    else if (bib == 2)
                    {
                        profile.Program.ProfilePage();

                    }
                    else
                    { 
                        Console.Clear();
                        Console.WriteLine("Felaktig Input");
                        goto Logged;
                    }
            }
            else if (llibrarian == 1){

			    Console.WriteLine("Vad vill du göra?");
			    Console.WriteLine("(1) Se och redigera alla användare");
			    Console.WriteLine("(2)Redigera böcker");
			    int libchoise = Convert.ToInt32(Console.ReadLine());
			        if (libchoise == 1)
			        {
                       string[] users1 = System.IO.File.ReadAllLines(@"C:\Users\klara\source\repos\Library\library\users.txt");
                        for (int i = 0; i < users.Length; i++)
                        {
                            var line1 = users1[i].Trim();
                            string[] parts1 = line1.Split(' ');
                            Console.WriteLine("(" + i + ")" + parts1[0]  + parts1[1]);
                            Console.WriteLine(" ");
                        }
                        Console.WriteLine("Välj användare");
                        int userchosen = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine(users1[userchosen]);

                        Console.WriteLine("(1)Redigera användaren");
                        int choise = Convert.ToInt32(Console.ReadLine());
                        if(choise == 1)
                         {
                            Console.WriteLine("Ange nytt förnamn, efternamn, personnummer och lösenord.");
                            Console.WriteLine("");

                            Console.Write("Förnamn: ");
                            var firstName = Console.ReadLine();

                            Console.Write("Efternamn: ");
                            var lastName = Console.ReadLine();

                            Console.Write("Personnummer: ");
                            var personalNumber = Console.ReadLine();

                            Console.Write("Lösenord: ");
                            var password = Console.ReadLine();

                            Console.Write("Skriv 1 för att göra användaren till biblotikarie. Annars skriv 0: ");
                            var librarian = Console.ReadLine();

                            var line1 = $"{firstName} {lastName} {personalNumber} {password} {librarian}";
                            string[] lines1 = { line1 };

                            Console.WriteLine("");

                               File.AppendAllLines(@"C:\Users\klara\source\repos\Library\library\users.txt", lines1);

                         }
                                                Console.ReadKey();

			        }
                    else if(libchoise == 2)
                    {
                        string[] books = System.IO.File.ReadAllLines(@"C:\Users\klara\source\repos\Library\library\books.txt");
                        for (int i = 0; i < books.Length; i++)
                        {
                            var line2 = books[i].Trim();
                            string[] parts2 = line2.Split(',');
                            Console.WriteLine("(" + i + ")" + parts2[0]  + parts2[1]);
                            Console.WriteLine(" ");

                        }
                        Console.WriteLine("Välj bok");
                        int bookchosen = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine(books[bookchosen]);

                        Console.WriteLine("(1)Redigera boken");
                        int choise = Convert.ToInt32(Console.ReadLine());
                        if(choise == 1)
                         {
                            Console.WriteLine("Ange ny titel, författare, isbn och hur många exemplar.");
                            Console.WriteLine("");

                            Console.Write("Titel: ");
                            var title = Console.ReadLine();

                            Console.Write("Förattare: ");
                            var author = Console.ReadLine();

                            Console.Write("ISBN: ");
                            var ISBN = Console.ReadLine();

                            Console.Write("exemplar: ");
                            var availability = Console.ReadLine();

                            var line2 = $"{title} {author} {ISBN} {availability}";
                            string[] lines2 = { line2 };

                            Console.WriteLine("");

                               File.AppendAllLines(@"C:\Users\klara\source\repos\Library\library\books.txt", lines2);
                    }
            }
           
        }

    }
   
    }
}
