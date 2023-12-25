// C# program to evaluate value of a postfix expression
using System;
using System.Collections;

namespace GFG {
class Geek {

	// Main() method
	static void Main()
	{
		Geek e = new Geek();
		e.v = ("1111++");
		e.expression();
		Console.WriteLine("postfix evaluation: "
						+ e.answer);
		Console.Read();
	}

	//'v' is variable to store the string value
	public string v;

	public string answer;
	Stack i = new Stack();

	// evaluation method
	public void expression()
	{
		int a, b, ans;
		for (int j = 0; j < v.Length; j++)
		{
			String c = v.Substring(j, 1);
			if (c.Equals("*")) {
				String sa = (String)i.Pop();
				String sb = (String)i.Pop();
				a = Convert.ToInt32(sb);
				b = Convert.ToInt32(sa);
				ans = a * b;
				i.Push(ans.ToString());
			}
			else if (c.Equals("/")) {
				String sa = (String)i.Pop();
				String sb = (String)i.Pop();
				a = Convert.ToInt32(sb);
				b = Convert.ToInt32(sa);
				ans = a / b;
				i.Push(ans.ToString());
			}
			else if (c.Equals("+")) {
				String sa = (String)i.Pop();
				String sb = (String)i.Pop();
				a = Convert.ToInt32(sb);
				b = Convert.ToInt32(sa);
				ans = a + b;
				i.Push(ans.ToString());
			}
			else if (c.Equals("-")) {
				String sa = (String)i.Pop();
				String sb = (String)i.Pop();
				a = Convert.ToInt32(sb);
				b = Convert.ToInt32(sa);
				ans = a - b;
				i.Push(ans.ToString());
			}
			else {
				i.Push(v.Substring(j, 1));
			}
		}
		answer = (String)i.Pop();
	}
}
}
