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

    }
   

}
