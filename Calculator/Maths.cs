using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
	public static class Maths
	{
		public static InputMethod textSource = InputMethod.defaultConsole;

		private static readonly String[] VERB =
		{
			"added",
			"subtracted",
			"multiplied",
			"divided"
		};
		private static readonly char[] SIGN =
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

		
		private static readonly Func<(double, double), double>[] SimpleMathFuncs = { Addition, Subtraction, Multiplication, Division };
		private static readonly Func<double[], double>[] ComplexMathFuncs = { Addition, Subtraction };

		public static readonly int MATH_SIMPLE = 0;
		public static readonly int MATH_COMPLEX = 1;
		public static readonly int[] OPS_OF_TYPE =
		{
			SimpleMathFuncs.Length,
			ComplexMathFuncs.Length
		};


		static readonly List<(double A, int operation, double B, double C)> results = new List<(double A, int operation, double B, double C)>();

		public static double SimpleMath(int operation)
		{
			if (!IsValidOperation(operation, MATH_SIMPLE))
			{
				Console.WriteLine("No such operation");
				return double.NaN;
			}

			double a, b;
			Console.WriteLine("Type the numbers that shall be {0}: ", VERB[operation]);

			a = ReadNumber(false);
			b = ReadNumber(operation==DIV);

			return SimpleMath(operation, (a, b));
		}
		public static double SimpleMath(int operation, double a, double b )
		{
			if (!IsValidOperation(operation, MATH_SIMPLE))
			{
				Console.WriteLine("No such operation");
				return double.NaN;
			}

			if (operation == DIV)
			{
				if (!ValidateNumber(true, b))
				{
					return double.NaN;
				}
			}

			return SimpleMath(operation, (a, b));
		}
		private static double SimpleMath(int operation, (double, double) nums)
		{
			double result = SimpleMathFuncs[operation]( nums );

			Console.WriteLine(MakeCalcString(results.Count-1));

			return result;
		}

		public static double ComplexMath(int operation)
		{
			if (!IsValidOperation(operation, MATH_COMPLEX))
			{
				Console.WriteLine("No such operation");
				return double.NaN;
			}
			int resultsBefore = results.Count;

			double result = ComplexMathFuncs[operation](ReadNumbers());

			Console.WriteLine(MakeCalcString(resultsBefore));

			return result;
		}
		public static double ComplexMath(int[] operations, double[] numbers)
		{
			foreach (int op in operations)
			{
				if (!IsValidOperation(op, MATH_COMPLEX))
				{
					Console.WriteLine("No such operation");
					return double.NaN;
				}
			}
			if (operations.Length == 1)
			{
				return ComplexMathFuncs[operations[0]](numbers);
			}
			else if (operations.Length == numbers.Length-1)
			{

				double result = 0;


				return result;
			}

			return 0;
		}
		private static bool	IsValidOperation(int operation, int opType)
		{
			return operation < OPS_OF_TYPE[opType];
		}

		private static double ReadNumber(bool divisor)
		{
			double input;

			while (true)
			{
				while (!double.TryParse(textSource.ReadLine(), out input))
				{
					Console.WriteLine("Not a number, try again!");
				}

				if (ValidateNumber(divisor, input)) break;
			}

			return input;
		}
		private static double[] ReadNumbers()
		{
			List<double> numbers = new List<double>();

			Console.WriteLine("Type a number and press enter repeatedly to enter multiple numbers, press enter again to finish:");

			double input;
			String s;

			while (true)
			{
				s = textSource.ReadLine();
				if (s.Length == 0)
				{
					if (numbers.Count < 2)
					{
						Console.WriteLine("Impossible to perform math on less than two values, try again.");
						continue;
					}
					break;
				}
				else if (!double.TryParse(s, out input))
				{
					Console.WriteLine("Not a number, try again!");
				}
				else
				{
					numbers.Add(input);
				}
			}

			return numbers.ToArray();
		}

		private static bool ValidateNumber(bool divisor, double num)
		{
			if (divisor && (num == 0))
			{
				Console.WriteLine("Divide by zero is undefined!");
				return false;
			}
			return true;
		}
		
		private static String MakeCalcString(int firstResult)
		{

			StringBuilder resultString = new StringBuilder();

			resultString.Append(results[firstResult].A);

			for (int i = firstResult; i < results.Count; i++)
			{
				resultString
					.Append(' ')
					.Append(SIGN[results[i].operation])
					.Append(' ')
					.Append(results[i].B);
			}

			resultString.Append(" = ").Append(results.Last().C);

			return resultString.ToString();
		}

		public static double Addition((double a, double b) nums)
		{
			double result = nums.a + nums.b;

			results.Add((nums.a, ADD, nums.b, result));

			return result;
		}
		public static double Addition(double[] numbers)
		{
			double result = 0;

			foreach (double num in numbers)
			{
				result = Addition((result, num));
			}
			return result;
		}

		public static double Subtraction((double a, double b) nums)
		{
			double result = nums.a - nums.b;

			results.Add((nums.a, SUB, nums.b, result));

			return result;
		}
		public static double Subtraction(double[] numbers)
		{
			// Uncomment this to subtract all numbers from 0
			double result = 0;

			// Uncomment this to subtract all trailing numbers from the first
			//double result = numbers[0];
			//numbers[0] = 0;

			foreach (double num in numbers)
			{
				result = Subtraction((result, num));
			}

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
			//if(!ValidateNumber(true, nums.b))
			//{
			//	throw new DivideByZeroException()
			//	{

			//	};
			//}
			if (!ValidateNumber(true, nums.b))
			{
				return double.NaN;
			}
			double result = nums.a / nums.b;

			results.Add((nums.a, DIV, nums.b, result));
			
			return result;
		}
	}
}
