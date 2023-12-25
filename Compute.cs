using System;
using System.Collections.Generic;

namespace infix
{
    public static class Compute
    {
        public static int CalculatePostfix(string expression)
        {
            var stack = InuputNumberPostfix(expression);
            foreach (char c in expression)
            {
                if (char.IsLetterOrDigit(c))
                {
                    continue;
                }
                else if (IsOperator(c))
                {
                    int operand2 = stack.Pop();
                    int operand1 = stack.Pop();
                    int result = PerformOperation(operand1, operand2, c);
                    stack.Push(result);
                }
            }
            return stack.Pop();
        }
        public static Stack<int> InuputNumberPostfix(string expression)
        {
            Stack<int> stack = new Stack<int>();
            var save = "";

            foreach (char c in expression)
            {
                if (char.IsLetterOrDigit(c))
                {
                    save += c;
                }
                else if (c == ',')
                {
                    Console.Write($"{save}: ");
                    save = "";
                    stack.Push(Convert.ToInt32(Console.ReadLine()));
                }
            }

            return stack;
        }
        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        static int PerformOperation(int operand1, int operand2, char op)
        {
            switch (op)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    return operand1 / operand2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
}