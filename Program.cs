using System;

namespace Infix_To_Postfix
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.Write("Enter your expression: ");
			var infix = Console.ReadLine();
			if (Validation.IsValid(infix))
			{
				var postfix = Convert.Postfix(infix);
				var compute = Compute.CalculatePostfix(postfix);
				Console.WriteLine(compute);
				return;
			}
			Console.WriteLine("This wrong!!!");
		}
	}
}