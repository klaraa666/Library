using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login;

namespace profile
{
    internal class Program
    {
        static public void ProfilePage()
        {
        profilestart:
            Console.WriteLine("Välkommen till profil sidan!");
            Console.WriteLine("vad vill du göra?");
            Console.WriteLine("(1)byta lösenord");
            Console.WriteLine("(2)Gå till bibloteket");
            int profilec = Convert.ToInt32(Console.ReadLine());
            if (profilec == 1)
            {
                PasswordChange();
            }
            else if (profilec == 2)
            {
                library.Program.LibraryPage();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Felaktig Input");
                goto profilestart;
            }
        }

        static public void PasswordChange()
        {
            string OldPasswordFromLogin = login.Program.password;
            Console.WriteLine("Ditt gamla lösenord:");
            string OldPassword = Console.ReadLine();
            Console.WriteLine("Ditt nya lösenord:");
            string NewPassword = Console.ReadLine();
            Console.WriteLine("Bekräfta ditt nya lösenord:");
            string NewPasswordConf = Console.ReadLine();

            if (NewPassword == NewPasswordConf)
            {
                if (OldPassword == OldPasswordFromLogin)
                {
                    if (ChangePassword(NewPassword))
                        Console.WriteLine("Ditt lösenord är nu ändrat!");
                }

            }
            else if (NewPassword != NewPasswordConf)
            {
                Console.WriteLine("Dina nya lösenord matchar inte");
            }

        }
        static bool ChangePassword(string newPassword)
        {
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\klara\source\repos\Library\library\users.txt");
            var line = users[login.Program.ID].Trim();
            string[] parts = line.Split(' ');

            //library.user user = new library.user( parts[4], newPassword);

            users[login.Program.ID] = $"{ parts[0]} {parts[1]} {parts[2]} {newPassword}";


            if (true)
            {
                File.WriteAllLines(@"C:\Users\klara\source\repos\Library\library\users.txt", users);
                return true;
            }

            return false;
        }

    }
}
