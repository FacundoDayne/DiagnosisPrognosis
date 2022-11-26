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

    //TO DO MAKE THIS INTO AN INTERFACE SO THAT IT COMPLIES WITH OPEN CLOSE PRINCIPLE
    public static class SymptomQueue
    {
        public static Queue<string> SymptomList = new Queue<string>();
    }
}