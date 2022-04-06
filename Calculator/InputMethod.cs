using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
	public class InputMethod
	{
		public Queue<String> inputStrings;
		private bool isConsole;

		public readonly static InputMethod defaultConsole = new InputMethod();

		public InputMethod(Queue<String> inputStrings)
		{
			this.inputStrings = inputStrings;
			isConsole = false;
		}

		private InputMethod()
		{
			isConsole = true;
		}

		public static InputMethod Console()
		{
			return defaultConsole;
		}

		public String ReadLine()
		{
			if (isConsole)
			{
				return NextConsole();
			}

			return NextString();
		}

		private String NextConsole()
		{
			return System.Console.ReadLine();
		}
		private String NextString()
		{
			return inputStrings.Dequeue();
		}
	}
}
