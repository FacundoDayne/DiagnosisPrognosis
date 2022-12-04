namespace DiagnosisPrognosis
{
    public static class Program
    {
        //String to hold the path to the file
        public static string thisLocation = System.Windows.Forms.Application.StartupPath;
        public static string databasePath;
        
        [STAThread]
        public static void Main(String[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }

    //TO DO MAKE THIS INTO AN INTERFACE SO THAT IT COMPLIES WITH OPEN CLOSE PRINCIPLE
    //public static class SymptomQueue
    //{
    //    public static Queue<string> SymptomList = new Queue<string>();
    //}
}