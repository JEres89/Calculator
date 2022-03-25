using System;
using System.Collections.Generic;

namespace Calculator
{
	static class Maths
	{

		private static readonly String[] Verb =
		{
			"adderas",
			"subtraheras",
			"multipliceras",
			"divideras"
		};
		private static readonly char[] Sign =
		{
			'+',
			'-',
			'*',
			'/'
		};

		public static readonly int ADD = 0;
		public static readonly int SUB = 1;
		public static readonly int MULT = 2;
		public static readonly int DIV = 3;
		
		private static readonly Func<(double, double), double>[] MathFuncs = { Addition, Subtraction, Multiplication, Division };



		static List<(double, int, double, double)> results = new();


		public static double SimpleMath(int func)
		{
			double a, b;
			Console.WriteLine("Skriv de två tal som skall {0}: ", Verb[func]);

			a = ReadNumber(false);
			b = ReadNumber(func==DIV);

			return Simplemath(func, (a, b));
		}

		public static double Simplemath(int func, double a, double b )
		{
			if (func == DIV)
			{
				if (!ValidateNumber(true, b))
				{
					return 0;
				}
			}

			return Simplemath(func, (a, b));
		}

		private static double Simplemath(int func, (double, double) nums)
		{
			MathFuncs[func]( nums );

			(double, int, double, double) result = results[results.Count-1];
			Console.WriteLine("{0} {1} {2} = {3}", result.Item1, Sign[result.Item2], result.Item3, result.Item4);

			return result.Item4;
		}


		private static double ReadNumber(bool divisor)
		{
			double input;

			while (true)
			{
				while (!double.TryParse(Console.ReadLine(), out input))
				{
					Console.WriteLine("Inte ett tal, försök igen");
				}

				if (ValidateNumber(divisor, input)) break;
			}

			return input;
		}
		private static bool ValidateNumber(bool divisor, double num)
		{
			if (divisor && (num == 0))
			{
				Console.WriteLine("Division med noll är odefinierat!");
				return false;
			}
			return true;
		}

		public static double Addition((double a, double b) nums)
		{
			double result = nums.a + nums.b;

			results.Add((nums.a, ADD, nums.b, result));

			return result;
		}
		public static double Subtraction((double a, double b) nums)
		{
			double result = nums.a - nums.b;

			results.Add((nums.a, SUB, nums.b, result));

			return result;
		}
		public static double Multiplication((double a, double b) nums)
		{
			double result = nums.a * nums.b;

			results.Add((nums.a, MULT, nums.b, result));

			return result;
		}
		public static double Division((double a, double b) nums)
		{
			double result = nums.a / nums.b;

			results.Add((nums.a, DIV, nums.b, result));

			return result;
		}
	}
}
