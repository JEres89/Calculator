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

		private static readonly Predicate<(decimal, decimal)>[] MathFuncs = { Addition, Subtraction, Multiplication, Division };

		public static void SimpleMath(int fun)
		{
			decimal a, b;
			Console.WriteLine("Skriv de två tal som skall {0} (OBS! decimaltecken skrivs med komma ','):", Verb[fun]);

			a = ReadNumber();
			b = ReadNumber();

			if (MathFuncs[fun]( (a, b) ))
			{
				(decimal, int, decimal, decimal) result = results[results.Count-1];
				Console.WriteLine("{0} {1} {2} = {3}", result.Item1, Sign[result.Item2], result.Item3, result.Item4);
			}
			else
			{
				Console.WriteLine("Division med noll är odefinierat");
			}
		}

		private static decimal ReadNumber()
		{
			decimal input;
			while (!decimal.TryParse(Console.ReadLine(), out input))
			{
				Console.WriteLine("Inte ett tal, försök igen");
			}
			return input;
		}


		static List<(decimal, int, decimal, decimal)> results = new();

		private static bool Addition((decimal a, decimal b) nums)
		{
			decimal result = nums.a + nums.b;

			results.Add((nums.a, 0, nums.b, result));

			return true;
		}
		public static bool Subtraction((decimal a, decimal b) nums)
		{
			decimal result = nums.a - nums.b;

			results.Add((nums.a, 1, nums.b, result));

			return true;
		}
		public static bool Multiplication((decimal a, decimal b) nums)
		{
			decimal result = nums.a * nums.b;

			results.Add((nums.a, 2, nums.b, result));

			return true;
		}
		public static bool Division((decimal a, decimal b) nums)
		{
			if (nums.b == 0)
			{
				return false;
			}

			decimal result = nums.a / nums.b;

			results.Add((nums.a, 3, nums.b, result));

			return true;
		}
	}
}
