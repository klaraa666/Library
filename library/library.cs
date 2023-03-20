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
            string[] books = System.IO.File.ReadAllLines(@"C:\Users\klara.hagelin\source\repos\library\library\books.txt");
            for (int i = 0; i < books.Length; i++){
            var line = books[i].Trim();
            string[] parts = line.Split(',');
                Console.WriteLine("("+i +")" +parts[0] +" av " +parts[1]);
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

            BookLoan();

        }
        public static void BookLoan()
        {
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("(1)Låna boken");
            Console.WriteLine("(2) Reservera Boken");
            int LoanOrReserve = Convert.ToInt32(Console.ReadLine());
            if (LoanOrReserve == 1)
            {

            }
            else if (LoanOrReserve == 2){

            }
        

        }
    }
}
