namespace login
{
    internal class Program
    {
        static public string password = "";
        static public string personalNumber = "";
        static public int ID;
        public static void LogInPage()
        {
            bool wrongpassword = false;
            

            while (!Authenticate(login.Program.personalNumber, login.Program.password))
            {
                //Console.Clear();

                if (wrongpassword)
                {
                    Console.WriteLine("Fel lösenord!");
                }
                else
                {
                    Console.WriteLine("Välkommen!");
                }

                Console.WriteLine("För att logga in ange personnummer och lösenord.");
                Console.WriteLine("");

                Console.Write("Personnummer: ");
                personalNumber = Console.ReadLine();

                Console.Write("Lösenord: ");
                login.Program.password = Console.ReadLine();

                Console.WriteLine("");

                wrongpassword = true;
            }
        }

        static bool Authenticate(string personalNumber, string password)
        {
            string[] users = System.IO.File.ReadAllLines(@"C:\Users\klara\source\repos\Library\library\users.txt");

            for (int i = 0; i < users.Length; i++)
            {
                var line = users[i].Trim();
                string[] parts = line.Split(' ');

                if (personalNumber == parts[2] && password == parts[3])
                {
                    ID = i;
                    return true;
                }
            }


            return false;
        }

    }
}
