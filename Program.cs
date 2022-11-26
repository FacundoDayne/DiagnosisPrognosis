namespace DiagnosisPrognosis
{
    internal static class Program
    {
        //String to hold the path to the file
        public static string thisLocation = System.Windows.Forms.Application.StartupPath;

        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new LandingForm());
        }
    }
}