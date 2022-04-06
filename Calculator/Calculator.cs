using System;

namespace Calculator
{
	public class Calculator
	{

		public static void Main(string[] args)
		{

			while (true)
			{
				Console.Clear();
				Console.WriteLine("-- Calculator -----------\n");
				Console.WriteLine("  1. Addition");
				Console.WriteLine("  2. Subtraction");
				Console.WriteLine("  3. Multiplication");
				Console.WriteLine("  4. Division");
				Console.WriteLine("  5. Additive sum");
				Console.WriteLine("  6. Subtractive sum");
				Console.WriteLine("  7. Freeform");
				Console.WriteLine("  8. Exit");
				Console.WriteLine("-------------------------\n");
				Console.Write("Select function, # + enter: ");

				String s = Console.ReadLine();

				int choice = s.Length == 0 ? 0 : Char.IsDigit(s[0]) ? (int)Char.GetNumericValue(s[0]) : 0 ;

				switch (choice)
				{
					case 1:
					case 2:
					case 3:
					case 4:
						Maths.SimpleMath(choice - 1); //index correction
						break;
					case 5:
						Maths.ComplexMath(Maths.ADD);
						break;
					case 6:
						Maths.ComplexMath(Maths.SUB);
						break;
					case 7:
						Console.WriteLine("Not implemented {0} {1} {2}", Maths.Division((0,0)), Maths.Division((1,0)), Maths.Division((-1,0)));
						break;
					case 8:
						return;
					default:
						Console.WriteLine("Invalid choice!");
						break;
				}

				Console.WriteLine("\n\nPress the any key.");
				Console.ReadKey();
			}
		}
	}
}
