using System;

namespace Calculator
{
	class Program
	{
		static void Main(string[] args)
		{

			while (true)
			{
				Console.Clear();
				Console.WriteLine("-- Calculator -----------\n");
				Console.WriteLine("  1. Addition");
				Console.WriteLine("  2. Subtraktion");
				Console.WriteLine("  3. Multiplikation");
				Console.WriteLine("  4. Division");
				Console.WriteLine("  5. Friform");
				Console.WriteLine("  6. Exit");
				Console.WriteLine("-------------------------\n");
				Console.Write("Välj funktion # + enter: ");

				String s = Console.ReadLine();

				int choice = s.Length == 0 ? 0 : Char.IsDigit(s[0]) ? (int)Char.GetNumericValue(s[0]) : 0 ;

				switch (choice)
				{
					case 0:
						Console.WriteLine("Ogiltigt val!");
						break;
					case 1:
					case 2:
					case 3:
					case 4:
						Maths.SimpleMath(choice - 1); //index correction
						break;
					case 5:
						Console.WriteLine("Ej implementerad");
						break;
					case 6:
						return;
					default:
						break;
				}

				Console.WriteLine("\n\nPress the any key.");
				Console.ReadKey();
			}
		}
	}
}
