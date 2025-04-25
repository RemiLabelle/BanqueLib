using BanqueLib;

namespace WinFormsSimulerCompte
{
    internal static class Program
    {
        private static Compte compte = new Compte(new Random().Next(1000,10000), "Rémi Labelle", new Random().Next(1, 100));
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(compte));
        }
    }
}