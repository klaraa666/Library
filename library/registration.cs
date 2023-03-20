using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registeration
{
    class Program
    {
 
        public static void RegistrationPage()
        {
            Console.WriteLine("För att registrera dig ange förnamn, efternamn, personnummer och lösenord.");
            Console.WriteLine("");

            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();

            Console.Write("Personnummer: ");
            var personalNumber = Console.ReadLine();

            Console.Write("Lösenord: ");
            var password = Console.ReadLine();

            var line = $"{firstName} {lastName} {personalNumber} {password} {"0"}";
            string[] lines = { line };

            Console.WriteLine("");

            if (UserInfoIncomplete(firstName, lastName, personalNumber, password))
            {
                Console.Clear();
                Console.WriteLine("Ange riktiga uppgifter för att kunna registrera dig.");
                Console.WriteLine("");
                RegistrationPage();
                return;
            }
            else if (UserRegistered(personalNumber))
            {
                Console.Clear();
                Console.WriteLine("Du är redan registrerad. Ange ett nytt personnummer för att registrera dig.");
                Console.WriteLine("");
                RegistrationPage();
                return;
            }

            File.AppendAllLines(@"C:\Users\klara.hagelin\source\repos\library\library\users.txt", lines);

            Console.WriteLine("Du är nu registrerad och kan logga in. Vänligen vänta för att skickas till inloggningssidan.");

            Thread.Sleep(6000);

            LoginPage();
        }

        static void LoginPage()
        {
            Console.Clear();

            Console.WriteLine("Välkommen!");


            Console.WriteLine("För att logga in ange personnummer och lösenord.");
            Console.WriteLine("");

            Console.Write("Personnummer: ");
            var personalNumber = Console.ReadLine();

            Console.Write("Lösenord: ");
            var password = Console.ReadLine();
        }

        static bool UserRegistered(string personalNumber)
        {
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\klara.hagelin\source\repos\library\library\users.txt");

            for (int i = 0; i < users.Length; i++)
            {
                var line = users[i].Trim();
                string[] parts = line.Split(' ');

                var currentPersonalNumber = parts[2];

                if (currentPersonalNumber == personalNumber)
                {
                    return true;
                }
            }

            return false;
        }

        static bool UserInfoIncomplete(string? firstName, string? lastName, string? personalNumber, string? password)
        {
            if (firstName == null || firstName == "") return true;
            if (lastName == null || lastName == "") return true;
            if (personalNumber == null || personalNumber == "") return true;
            if (password == null || password == "") return true;

            return false;
        }
    }
}
