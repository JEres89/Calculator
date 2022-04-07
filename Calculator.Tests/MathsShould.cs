using System;
using Xunit;
using System.Collections.Generic;


namespace Calculator.Tests
{
	public class MathsShould
	{
		Random rand = new Random();

		[Fact]
		public void NotDivideByZero()
		{
			double zeroDiv_ByOpTest = Maths.SimpleMath(Maths.DIV, 100, 0);

			double zeroDiv_TupleTest = Maths.Division((100, 0));

			Queue<String> zeroDiv_InputStrings =
				new Queue<String>(new String[]{
				"100",
				"0",
				"1000",
			});

			Maths.textSource = new InputMethod(zeroDiv_InputStrings);

			double zeroDiv_Input = 100 / 1000;
			double zeroDiv_InputTest = Maths.SimpleMath(Maths.DIV);

			Assert.Equal(double.NaN, zeroDiv_ByOpTest, 0);
			Assert.Equal(double.NaN, zeroDiv_TupleTest, 0);
			Assert.Equal(zeroDiv_Input, zeroDiv_InputTest, 0);
			Maths.textSource = InputMethod.defaultConsole;
		}

		[Fact]
		public void Add()
		{
			double a, b;
			double add_Tuple = (a = rand.NextDouble()) + (b = rand.NextDouble());
			double add_TupleTest = Maths.Addition((a, b));

			double add_ByOp = (a = rand.NextDouble()) + (b = rand.NextDouble());
			double add_ByOpTest = Maths.SimpleMath(Maths.ADD, a, b);

			Assert.Equal(add_TupleTest, add_Tuple, 10);
			Assert.Equal(add_ByOpTest, add_ByOp, 10);
		}

		[Fact]
		public void Subtract()
		{
			double a, b;
			double subtract_Tuple = (a = rand.NextDouble()) - (b = rand.NextDouble());
			double subtract_TupleTest = Maths.Subtraction((a, b));

			double subtract_ByOp = (a = rand.NextDouble()) - (b = rand.NextDouble());
			double subtract_ByOpTest = Maths.SimpleMath(Maths.SUB, a, b);

			Assert.Equal(subtract_TupleTest, subtract_Tuple, 10);
			Assert.Equal(subtract_ByOpTest, subtract_ByOp, 10);
		}

		[Fact]
		public void Multiply()
		{
			double a, b;
			double multiply_Tuple = (a = rand.NextDouble()) * (b = rand.NextDouble());
			double multiply_TupleTest = Maths.Multiplication((a, b));

			double multiply_ByOp = (a = rand.NextDouble()) * (b = rand.NextDouble());
			double multiply_ByOpTest = Maths.SimpleMath(Maths.MULT, a, b);

			Assert.Equal(multiply_TupleTest, multiply_Tuple, 10);
			Assert.Equal(multiply_ByOpTest, multiply_ByOp, 10);
		}

		[Fact]
		public void Divide()
		{
			double a, b;
			double divide_Tuple = (a = rand.NextDouble()) / (b = rand.NextDouble());
			double divide_TupleTest = Maths.Division((a, b));

			double divide_ByOp = (a = rand.NextDouble()) / (b = rand.NextDouble());
			double divide_ByOpTest = Maths.SimpleMath(Maths.DIV, a, b);

			Assert.Equal(divide_TupleTest, divide_Tuple, 10);
			Assert.Equal(divide_ByOpTest, divide_ByOp, 10);
		}

		[Fact]
		public void Sum()
		{
			double[] values = new double[5];
			double sum = 0;

			for (int i = 0; i < values.Length; i++)
			{
				values[i] = rand.NextDouble();
				sum += values[i];
			}

			double sumAddTest = Maths.Addition(values);
			double sumAddByOpTest = Maths.ComplexMath(new int[] {Maths.ADD}, values);

			sum = 0;

			for (int i = 0; i < values.Length; i++)
			{
				sum -= values[i];
			}

			double sumSubTest = Maths.Subtraction(values);
			double sumSubByOpTest = Maths.ComplexMath(new int[] { Maths.SUB }, values);

			Assert.Equal(sumAddTest, -sum, 10);
			Assert.Equal(sumAddByOpTest, -sum, 10);
			Assert.Equal(sumSubTest, sum, 10);
			Assert.Equal(sumSubByOpTest, sum, 10);
		}

		[Fact]
		public void TakeInput()
		{
			double a = rand.NextDouble();
			double b = rand.NextDouble();

			String[] inputValues = new String[]{
				a.ToString(),
				b.ToString()
			};

			Queue<String> string_Queue = new Queue<String>(inputValues);
			Maths.textSource = new InputMethod(string_Queue);


			double add_Input = a + b;
			double add_InputTest = Maths.SimpleMath(Maths.ADD);

			string_Queue = new Queue<string>(inputValues);
			Maths.textSource = new InputMethod(string_Queue);

			double subtract_Input = a - b;
			double subtract_InputTest = Maths.SimpleMath(Maths.SUB);

			string_Queue = new Queue<string>(inputValues);
			Maths.textSource = new InputMethod(string_Queue);

			double multiply_Input = a * b;
			double multiply_InputTest = Maths.SimpleMath(Maths.MULT);

			string_Queue = new Queue<string>(inputValues);
			Maths.textSource = new InputMethod(string_Queue);

			double divide_Input = a / b;
			double divide_InputTest = Maths.SimpleMath(Maths.DIV);

			inputValues = new string[11];

			double add_ComplexInput = 0;
			double subtract_ComplexInput = 0;

			for (int i = 0; i < 10; i++)
			{
				double d = rand.NextDouble();
				add_ComplexInput += d;
				subtract_ComplexInput -= d;

				inputValues[i] = d.ToString();
			}

			inputValues[10] = "";

			string_Queue = new Queue<String>(inputValues);
			Maths.textSource = new InputMethod(string_Queue);
			double add_ComplexInputTest = Maths.ComplexMath(Maths.ADD);

			string_Queue = new Queue<String>(inputValues);
			Maths.textSource = new InputMethod(string_Queue);
			double subtract_ComplexInputTest = Maths.ComplexMath(Maths.SUB);


			Assert.Equal(add_InputTest, add_Input, 10);
			Assert.Equal(subtract_InputTest, subtract_Input, 10);
			Assert.Equal(multiply_InputTest, multiply_Input, 10);
			Assert.Equal(divide_InputTest, divide_Input, 10);
			Assert.Equal(add_ComplexInputTest, add_ComplexInput, 10);
			Assert.Equal(subtract_ComplexInputTest, subtract_ComplexInput, 10);
		}
	}
}