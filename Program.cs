using System;

namespace DiagnosisPrognosis
{
    public static class Program
    {
		
        public static void Main(String[] args)
        {
			Console.WriteLine("Serverification");

			if (args.Length > 0)
			{
				foreach (string x in args)
				{
					Console.WriteLine(x);
				}
			}

			if (args.Length == 0)
			{
				Termination(1);
			}

			string[] ipOctetSplit = args[0].Split('.');
			foreach (string x in ipOctetSplit)
			{
				try
				{
					if (!(Int32.Parse(x) >= 0) || !(Int32.Parse(x) <= 255))
					{
						Termination(0);
					}
				}
				catch (FormatException)
				{
					Termination(0);
				}
			}

			Communications.StartServer(args[0]);

			Console.ReadKey();
        }

		private static void Termination(int id)
		{
			string error = "";
			switch (id)
			{
				case 0:
					error = "Invalid IP Address.";
					break;
				case 1:
					error = "No IP Address.";
					break;
				default:
					error = "Argument error.";
					break;
			}
			Console.WriteLine($"{error}\nTerminating Program\nPress any key to continue...");
			Console.ReadKey();
			Environment.Exit(0);
		}
    }
}