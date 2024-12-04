namespace BankingApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            Console.WriteLine("Apple");
            Console.WriteLine("Apple2");

            Console.WriteLine("Chester");
            Console.WriteLine("Gab");
            Console.WriteLine("Gab2");
            Console.WriteLine("Gab3");
            Console.WriteLine("test");
            Console.WriteLine("Ayushi");
            
        }
    }
}